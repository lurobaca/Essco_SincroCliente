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
    long TotalRows,
    string? ActiveAgent,
    string? CurrentProcess,
    bool? DownloadFromFtp,
    bool? TodayBlocked,
    IReadOnlyList<string> FtpAlerts);

/// <summary>
/// Contiene las señales que el formulario original actualizaba mediante Timer.
/// </summary>
public sealed record TransmissionSignals(
    string? ActiveAgent,
    string? CurrentProcess,
    bool? DownloadFromFtp,
    bool? TodayBlocked);

/// <summary>
/// Define las consultas y mutaciones de la bitácora de transmisión heredada.
/// </summary>
public interface ITransmissionStatusRepository
{
    /// <summary>
    /// Consulta resultados y señales operativas sin modificar el estado del proceso.
    /// </summary>
    Task<TransmissionSnapshot> ReadAsync(string? agent, string fileType, string status, int page, CancellationToken cancellationToken);

    /// <summary>
    /// Consulta únicamente las señales operativas para la actualización periódica.
    /// </summary>
    Task<TransmissionSignals> ReadSignalsAsync(CancellationToken cancellationToken);

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

    /// <summary>
    /// Comprueba que el código identifica a un agente del catálogo heredado.
    /// </summary>
    Task<bool> AgentExistsAsync(string agent, CancellationToken cancellationToken);

    /// <summary>
    /// Lista los agentes que el botón Recargar Todos recorría en WinForms.
    /// </summary>
    Task<IReadOnlyList<string>> ListDispatchAgentsAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Limpia los dos estados del agente y opcionalmente marca sus archivos para recarga.
    /// </summary>
    Task PrepareDispatchAsync(string agent, bool reload, CancellationToken cancellationToken);

    /// <summary>
    /// Sustituye la prioridad global del agente después de preparar el envío.
    /// </summary>
    Task QueueAgentAsync(string agent, CancellationToken cancellationToken);
}

/// <summary>
/// Publica la señal que Syncro Server consume desde el FTP heredado.
/// </summary>
public interface ITransmissionSignalSender
{
    bool IsConfigured { get; }

    /// <summary>
    /// Envía la señal del agente al directorio Revisame del FTP.
    /// </summary>
    Task SendAsync(string agent, CancellationToken cancellationToken);
}
