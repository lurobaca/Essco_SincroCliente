using System.Data;
using System.Globalization;
using Essco.Application.Billing;
using Microsoft.Data.SqlClient;

namespace Essco.Infrastructure.Data;

/// <summary>
/// Accede a la bitácora y a las señales operativas del servidor heredado.
/// </summary>
public sealed class SqlServerTransmissionStatusRepository(string connectionString, int commandTimeout) : ITransmissionStatusRepository
{
    /// <inheritdoc />
    public async Task<TransmissionSnapshot> ReadAsync(
        string? agent,
        string fileType,
        string status,
        int page,
        CancellationToken cancellationToken)
    {
        if (page < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(page));
        }

        await using var connection = await OpenAsync(cancellationToken);
        await using var command = CreateCommand(connection, """
            SELECT [Agente], [Archivo], [Consecutivo], [Estado],
                [Detalle], [Fecha], [Reintento], COUNT_BIG(*) OVER () AS [TotalRows]
            FROM [dbo].[Estado_Subida_SAP]
            WHERE (@Agent IS NULL OR [Agente] = @Agent)
                AND (@FileName IS NULL OR [Archivo] = @FileName)
                AND (@Status IS NULL OR [Estado] = @Status)
            ORDER BY [Agente] ASC, [Fecha] DESC, [Archivo] ASC, [Consecutivo] ASC
            OFFSET @Offset ROWS FETCH NEXT 500 ROWS ONLY
            """);

        string? fileName = fileType switch
        {
            "Pedidos" => "pedidos.mbg",
            "Devoluciones" => "devoluciones.mbg",
            "Pagos" => "pagos.mbg",
            _ => null
        };
        command.Parameters.Add("@Agent", SqlDbType.VarChar, 30).Value =
            string.IsNullOrWhiteSpace(agent) ? DBNull.Value : agent.Trim();
        command.Parameters.Add("@FileName", SqlDbType.VarChar, 50).Value =
            fileName is null ? DBNull.Value : fileName;
        command.Parameters.Add("@Status", SqlDbType.NChar, 20).Value =
            status == "Todos" ? DBNull.Value : status;
        command.Parameters.Add("@Offset", SqlDbType.Int).Value = checked((page - 1) * 500);

        var rows = new List<TransmissionRow>();
        long totalRows = 0;
        await using (var reader = await command.ExecuteReaderAsync(cancellationToken))
        {
            while (await reader.ReadAsync(cancellationToken))
            {
                totalRows = reader.GetInt64(7);
                rows.Add(new TransmissionRow(
                    ReadText(reader, 0),
                    ReadText(reader, 1),
                    ReadText(reader, 2),
                    ReadText(reader, 3),
                    ReadText(reader, 4),
                    ReadText(reader, 5),
                    ReadText(reader, 6)));
            }
        }

        TransmissionSignals signals = await ReadSignalsAsync(connection, cancellationToken);
        var alerts = await ReadFtpAlertsAsync(connection, cancellationToken);

        return new TransmissionSnapshot(
            rows,
            totalRows,
            signals.ActiveAgent,
            signals.CurrentProcess,
            signals.DownloadFromFtp,
            signals.TodayBlocked,
            alerts);
    }

    /// <inheritdoc />
    public async Task<TransmissionSignals> ReadSignalsAsync(CancellationToken cancellationToken)
    {
        await using var connection = await OpenAsync(cancellationToken);
        return await ReadSignalsAsync(connection, cancellationToken);
    }

    /// <summary>
    /// Lee las cuatro señales originales sin volver a cargar la bitácora completa.
    /// </summary>
    private async Task<TransmissionSignals> ReadSignalsAsync(
        SqlConnection connection,
        CancellationToken cancellationToken)
    {
        string? activeAgent = await ReadControlValueAsync(
            connection,
            "SELECT TOP (1) [AgenteEnSecuencia] FROM [dbo].[AgenteAEjecutar]",
            cancellationToken);
        string? currentProcess = await ReadControlValueAsync(
            connection,
            "SELECT TOP (1) [Procesando] FROM [dbo].[ProcesoEnEjecucion]",
            cancellationToken);
        string? ftpFlag = await ReadControlValueAsync(
            connection,
            "SELECT TOP (1) [BajarDeFTP] FROM [dbo].[BajarDeFTP]",
            cancellationToken);
        bool? downloadFromFtp = ftpFlag switch
        {
            "0" => true,
            "1" => false,
            _ => null
        };
        string? todayFlag = await ReadControlValueAsync(
            connection,
            "SELECT TOP (1) [HoySi] FROM [dbo].[FiltraHOY]",
            cancellationToken);
        bool? todayBlocked = todayFlag switch
        {
            "1" => true,
            "0" => false,
            _ => null
        };

        return new TransmissionSignals(activeAgent, currentProcess, downloadFromFtp, todayBlocked);
    }

    /// <inheritdoc />
    public async Task<int> ClearAsync(string agent, string status, CancellationToken cancellationToken)
    {
        await using var connection = await OpenAsync(cancellationToken);
        await using var command = CreateCommand(
            connection,
            "DELETE FROM [dbo].[Estado_Subida_SAP] WHERE [Agente] = @Agent AND [Estado] = @Status");
        command.Parameters.Add("@Agent", SqlDbType.VarChar, 30).Value = agent;
        command.Parameters.Add("@Status", SqlDbType.NChar, 20).Value = status;
        return await command.ExecuteNonQueryAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<int> RetryAsync(
        string agent,
        string file,
        string consecutive,
        string date,
        CancellationToken cancellationToken)
    {
        await using var connection = await OpenAsync(cancellationToken);
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync(
            IsolationLevel.Serializable,
            cancellationToken);
        await using var command = CreateCommand(connection, """
            SELECT COUNT_BIG(*) FROM [dbo].[Estado_Subida_SAP] WITH (UPDLOCK, HOLDLOCK)
            WHERE [Agente] = @Agent AND [Archivo] = @File
                AND [Consecutivo] = @Consecutive AND [Fecha] = @Date AND [Estado] = 'ERROR'
            """);
        command.Transaction = transaction;
        command.Parameters.Add("@Agent", SqlDbType.VarChar, 30).Value = agent;
        command.Parameters.Add("@File", SqlDbType.VarChar, 100).Value = file;
        command.Parameters.Add("@Consecutive", SqlDbType.VarChar, 100).Value = consecutive;
        command.Parameters.Add("@Date", SqlDbType.VarChar, 100).Value = date;

        long matching = Convert.ToInt64(await command.ExecuteScalarAsync(cancellationToken));
        if (matching != 1)
        {
            return matching > 1 ? -1 : 0;
        }

        command.CommandText = """
            UPDATE [dbo].[Estado_Subida_SAP] SET [Reintento] = 1
            WHERE [Agente] = @Agent AND [Archivo] = @File
                AND [Consecutivo] = @Consecutive AND [Fecha] = @Date AND [Estado] = 'ERROR'
            """;
        int affected = await command.ExecuteNonQueryAsync(cancellationToken);
        if (affected == 1)
        {
            await transaction.CommitAsync(cancellationToken);
        }

        return affected;
    }

    /// <inheritdoc />
    public async Task<int> SetSourceAsync(bool downloadFromFtp, CancellationToken cancellationToken)
    {
        await using var connection = await OpenAsync(cancellationToken);
        await using var command = CreateCommand(connection, """
            IF (SELECT COUNT_BIG(*) FROM [dbo].[BajarDeFTP]) = 1
                UPDATE [dbo].[BajarDeFTP] SET [BajarDeFTP] = @Value
            """);
        command.Parameters.Add("@Value", SqlDbType.Int).Value = downloadFromFtp ? 0 : 1;
        return await command.ExecuteNonQueryAsync(cancellationToken);
    }

    /// <inheritdoc />
    public async Task<bool> AgentExistsAsync(string agent, CancellationToken cancellationToken)
    {
        if (!int.TryParse(agent, NumberStyles.None, CultureInfo.InvariantCulture, out int agentCode))
        {
            return false;
        }

        await using var connection = await OpenAsync(cancellationToken);
        await using var command = CreateCommand(connection, """
            SELECT COUNT_BIG(*)
            FROM [dbo].[Agentes]
            WHERE [CodAgente] = @Agent AND [Puesto] = 'AGENTE'
            """);
        command.Parameters.Add("@Agent", SqlDbType.Int).Value = agentCode;
        return Convert.ToInt64(await command.ExecuteScalarAsync(cancellationToken)) == 1;
    }

    /// <inheritdoc />
    public async Task<IReadOnlyList<string>> ListDispatchAgentsAsync(CancellationToken cancellationToken)
    {
        await using var connection = await OpenAsync(cancellationToken);
        await using var command = CreateCommand(connection, """
            SELECT [CodAgente]
            FROM [dbo].[Agentes]
            WHERE [Puesto] = 'AGENTE'
            ORDER BY [CodAgente]
            """);
        var agents = new List<string>();
        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            agents.Add(Convert.ToString(reader.GetValue(0)) ?? string.Empty);
        }

        return agents;
    }

    /// <inheritdoc />
    public async Task PrepareDispatchAsync(string agent, bool reload, CancellationToken cancellationToken)
    {
        if (!int.TryParse(agent, NumberStyles.None, CultureInfo.InvariantCulture, out int agentCode))
        {
            throw new ArgumentException("El agente debe ser un número válido.", nameof(agent));
        }

        await using var connection = await OpenAsync(cancellationToken);
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync(cancellationToken);

        try
        {
            await using var agentCommand = CreateCommand(connection, """
                SELECT COUNT_BIG(*)
                FROM [dbo].[Agentes] WITH (UPDLOCK, HOLDLOCK)
                WHERE [CodAgente] = @Agent AND [Puesto] = 'AGENTE'
                """);
            agentCommand.Transaction = transaction;
            agentCommand.Parameters.Add("@Agent", SqlDbType.Int).Value = agentCode;
            long matchingAgents = Convert.ToInt64(
                await agentCommand.ExecuteScalarAsync(cancellationToken));
            if (matchingAgents != 1)
            {
                throw new InvalidOperationException("El agente ya no está disponible para transmitir.");
            }

            await using var clearCommand = CreateCommand(connection, """
                DELETE FROM [dbo].[Estado_Subida_SAP]
                WHERE [Agente] = @Agent AND [Estado] IN ('ERROR', 'SUBIDO')
                """);
            clearCommand.Transaction = transaction;
            clearCommand.Parameters.Add("@Agent", SqlDbType.VarChar, 30).Value = agent;
            await clearCommand.ExecuteNonQueryAsync(cancellationToken);

            if (reload)
            {
                await using var reloadCommand = CreateCommand(connection, """
                    UPDATE [dbo].[Agentes]
                    SET [Recargar] = 1
                    WHERE [CodAgente] = @Agent AND [Puesto] = 'AGENTE'
                    """);
                reloadCommand.Transaction = transaction;
                reloadCommand.Parameters.Add("@Agent", SqlDbType.Int).Value = agentCode;
                if (await reloadCommand.ExecuteNonQueryAsync(cancellationToken) != 1)
                {
                    throw new InvalidOperationException("No se pudo marcar la recarga del agente.");
                }
            }

            await transaction.CommitAsync(cancellationToken);
        }
        catch
        {
            await transaction.RollbackAsync(CancellationToken.None);
            throw;
        }
    }

    /// <inheritdoc />
    public async Task QueueAgentAsync(string agent, CancellationToken cancellationToken)
    {
        if (agent.Length is < 1 or > 10 || !agent.All(char.IsDigit))
        {
            throw new ArgumentException("El agente debe ser un número válido.", nameof(agent));
        }

        await using var connection = await OpenAsync(cancellationToken);
        await using var transaction = (SqlTransaction)await connection.BeginTransactionAsync(
            IsolationLevel.Serializable,
            cancellationToken);

        try
        {
            await using var command = CreateCommand(connection, """
                SELECT COUNT_BIG(*) FROM [dbo].[AgenteAEjecutar] WITH (TABLOCKX, HOLDLOCK)
                """);
            command.Transaction = transaction;
            long rows = Convert.ToInt64(await command.ExecuteScalarAsync(cancellationToken));
            if (rows > 1)
            {
                throw new InvalidOperationException("La prioridad de agentes contiene más de una fila.");
            }

            command.CommandText = "DELETE FROM [dbo].[AgenteAEjecutar]";
            await command.ExecuteNonQueryAsync(cancellationToken);
            command.CommandText = """
                INSERT INTO [dbo].[AgenteAEjecutar] ([EjecAgente])
                VALUES (@Agent)
                """;
            command.Parameters.Add("@Agent", SqlDbType.NChar, 10).Value = agent;
            await command.ExecuteNonQueryAsync(cancellationToken);
            await transaction.CommitAsync(cancellationToken);
        }
        catch
        {
            await transaction.RollbackAsync(CancellationToken.None);
            throw;
        }
    }

    /// <summary>
    /// Lee un valor de control sin interpretar la ausencia como un estado conocido.
    /// </summary>
    private async Task<string?> ReadControlValueAsync(
        SqlConnection connection,
        string query,
        CancellationToken cancellationToken)
    {
        await using var command = CreateCommand(connection, query);
        object? value = await command.ExecuteScalarAsync(cancellationToken);
        return value is null or DBNull ? null : Convert.ToString(value)?.Trim();
    }

    /// <summary>
    /// Lee las alertas activas sin consumir la señal que procesa WinForms.
    /// </summary>
    private async Task<IReadOnlyList<string>> ReadFtpAlertsAsync(
        SqlConnection connection,
        CancellationToken cancellationToken)
    {
        await using var command = CreateCommand(connection, """
            SELECT TOP (10) [Agente], [Archivo]
            FROM [dbo].[AlertaFTPAgSolicitado]
            WHERE [InfoTransmision] = 1
            ORDER BY [Agente]
            """);
        var alerts = new List<string>();
        await using var reader = await command.ExecuteReaderAsync(cancellationToken);
        while (await reader.ReadAsync(cancellationToken))
        {
            alerts.Add($"No se encontró el archivo {ReadText(reader, 1)} del agente {ReadText(reader, 0)} en FTP.");
        }

        return alerts;
    }

    /// <summary>
    /// Abre una conexión nueva para cada operación y la libera al finalizar.
    /// </summary>
    private async Task<SqlConnection> OpenAsync(CancellationToken cancellationToken)
    {
        var connection = new SqlConnection(connectionString);
        await connection.OpenAsync(cancellationToken);
        return connection;
    }

    /// <summary>
    /// Aplica el tiempo máximo configurado a las consultas del repositorio.
    /// </summary>
    private SqlCommand CreateCommand(SqlConnection connection, string query)
    {
        return new SqlCommand(query, connection) { CommandTimeout = commandTimeout };
    }

    /// <summary>
    /// Conserva los valores nulos y tipos heredados como texto de presentación.
    /// </summary>
    private static string ReadText(SqlDataReader reader, int ordinal)
    {
        return reader.IsDBNull(ordinal)
            ? string.Empty
            : Convert.ToString(reader.GetValue(ordinal)) ?? string.Empty;
    }
}
