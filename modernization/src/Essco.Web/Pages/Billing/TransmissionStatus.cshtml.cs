using System.Data;
using Essco.Application.Configuration;
using Essco.Application.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace Essco.Web.Pages.Billing;

/// <summary>
/// Consulta los estados de transmisión registrados por Syncro Cliente sin alterar la cola heredada.
/// </summary>
[Authorize(Policy = Permissions.Billing)]
public sealed class TransmissionStatusModel(IConfiguration configuration, IOptions<EsscoOptions> options) : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string? Agent { get; set; }

    [BindProperty(SupportsGet = true)]
    public string FileType { get; set; } = "Todos";

    [BindProperty(SupportsGet = true)]
    public string Status { get; set; } = "ERROR";

    public IReadOnlyList<TransmissionRow> Items { get; private set; } = [];
    public string? ErrorMessage { get; private set; }

    /// <summary>
    /// Filtra la tabla heredada con parámetros y limita la cantidad de filas mostradas.
    /// </summary>
    public async Task OnGetAsync(CancellationToken cancellationToken)
    {
        if (Agent is { Length: > 30 } ||
            (Agent is not null && Agent.Any(character => !char.IsDigit(character))) ||
            FileType is not ("Todos" or "Pedidos" or "Devoluciones" or "Pagos") ||
            Status is not ("Todos" or "ERROR" or "SUBIDO"))
        {
            ErrorMessage = "Los filtros indicados no son válidos.";
            return;
        }

        var sqlOptions = options.Value.SqlServer;
        string? connectionString = configuration.GetConnectionString(sqlOptions.ConnectionStringName);
        if (!sqlOptions.Enabled || string.IsNullOrWhiteSpace(connectionString))
        {
            ErrorMessage = "La conexión de Syncro Cliente no está configurada.";
            return;
        }

        string? fileName = FileType switch
        {
            "Pedidos" => "pedidos.mbg",
            "Devoluciones" => "devoluciones.mbg",
            "Pagos" => "pagos.mbg",
            _ => null
        };

        try
        {
            await using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync(cancellationToken);
            await using var command = connection.CreateCommand();
            command.CommandTimeout = sqlOptions.CommandTimeoutSeconds;
            command.CommandText = """
                SELECT TOP (500) [Agente], [Archivo], [Consecutivo], [Estado],
                    [Detalle], [Fecha], [Reintento]
                FROM [dbo].[Estado_Subida_SAP]
                WHERE (@Agent IS NULL OR [Agente] = @Agent)
                    AND (@FileName IS NULL OR [Archivo] = @FileName)
                    AND (@Status IS NULL OR [Estado] = @Status)
                ORDER BY [Agente] ASC, [Fecha] DESC
                """;
            command.Parameters.Add("@Agent", SqlDbType.NVarChar, 30).Value =
                string.IsNullOrWhiteSpace(Agent) ? DBNull.Value : Agent.Trim();
            command.Parameters.Add("@FileName", SqlDbType.NVarChar, 50).Value =
                fileName is null ? DBNull.Value : fileName;
            command.Parameters.Add("@Status", SqlDbType.NVarChar, 20).Value =
                Status == "Todos" ? DBNull.Value : Status;

            var rows = new List<TransmissionRow>();
            await using var reader = await command.ExecuteReaderAsync(cancellationToken);
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

            Items = rows;
        }
        catch (SqlException)
        {
            ErrorMessage = "No fue posible consultar los estados de transmisión. Verifique la conexión y la tabla de Syncro Cliente.";
        }
    }

    /// <summary>
    /// Conserva la representación textual de las columnas heredadas, que pueden contener valores nulos.
    /// </summary>
    private static string ReadText(SqlDataReader reader, int ordinal)
    {
        return reader.IsDBNull(ordinal) ? string.Empty : Convert.ToString(reader.GetValue(ordinal)) ?? string.Empty;
    }
}

/// <summary>
/// Representa una fila de la bitácora heredada de transmisión hacia SAP.
/// </summary>
public sealed record TransmissionRow(
    string Agent,
    string File,
    string Consecutive,
    string Status,
    string Detail,
    string Date,
    string Retry);
