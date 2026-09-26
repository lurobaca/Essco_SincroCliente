namespace Essco.Application.Billing;

/// <summary>
/// Representa un resultado heredado de la transmisión de archivos hacia SAP.
/// </summary>
public sealed record TransmissionRow(
    string Agent,
    string File,
    string Consecutive,
    string Status,
    string Detail,
    string Date,
    string Retry);

/// <summary>
/// Agrupa los resultados y señales operativas mostrados en la pantalla.
/// </summary>
public sealed record TransmissionSnapshot(
    IReadOnlyList<TransmissionRow> Rows,
    string? ActiveAgent,
    string? CurrentProcess,
    bool? DownloadFromFtp,
    IReadOnlyList<string> FtpAlerts);

/// <summary>
/// Define las consultas y mutaciones de la bitácora de transmisión heredada.
/// </summary>
public interface ITransmissionStatusRepository
{
    /// <summary>
    /// Consulta resultados y señales operativas sin modificar el estado del proceso.
    /// </summary>
    Task<TransmissionSnapshot> ReadAsync(string? agent, string fileType, string status, CancellationToken cancellationToken);

    /// <summary>
    /// Elimina resultados de un solo agente y estado explícito.
    /// </summary>
    Task<int> ClearAsync(string agent, string status, CancellationToken cancellationToken);

    /// <summary>
    /// Marca un resultado inequívoco para reintento y devuelve las filas afectadas.
    /// </summary>
    Task<int> RetryAsync(string agent, string file, string consecutive, string date, CancellationToken cancellationToken);

    /// <summary>
    /// Selecciona FTP o lectura local si existe una sola fila de configuración.
    /// </summary>
    Task<int> SetSourceAsync(bool downloadFromFtp, CancellationToken cancellationToken);
}
