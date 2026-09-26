using System.Data;
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
        CancellationToken cancellationToken)
    {
        await using var connection = await OpenAsync(cancellationToken);
        await using var command = CreateCommand(connection, """
            SELECT TOP (500) [Agente], [Archivo], [Consecutivo], [Estado],
                [Detalle], [Fecha], [Reintento]
            FROM [dbo].[Estado_Subida_SAP]
            WHERE (@Agent IS NULL OR [Agente] = @Agent)
                AND (@FileName IS NULL OR [Archivo] = @FileName)
                AND (@Status IS NULL OR [Estado] = @Status)
            ORDER BY [Agente] ASC, [Fecha] DESC
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

        var rows = new List<TransmissionRow>();
        await using (var reader = await command.ExecuteReaderAsync(cancellationToken))
        {
            while (await reader.ReadAsync(cancellationToken))
            {
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
        var alerts = await ReadFtpAlertsAsync(connection, cancellationToken);

        return new TransmissionSnapshot(rows, activeAgent, currentProcess, downloadFromFtp, alerts);
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
