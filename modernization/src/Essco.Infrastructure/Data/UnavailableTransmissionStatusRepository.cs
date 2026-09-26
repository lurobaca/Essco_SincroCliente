using Essco.Application.Billing;

namespace Essco.Infrastructure.Data;

/// <summary>
/// Impide presentar como exitosas operaciones de transmisión sin base configurada.
/// </summary>
public sealed class UnavailableTransmissionStatusRepository : ITransmissionStatusRepository
{
    /// <inheritdoc />
    public Task<TransmissionSnapshot> ReadAsync(string? agent, string fileType, string status, CancellationToken cancellationToken)
    {
        throw new InvalidOperationException("La conexión de Syncro Cliente no está configurada.");
    }

    /// <inheritdoc />
    public Task<int> ClearAsync(string agent, string status, CancellationToken cancellationToken)
    {
        throw new InvalidOperationException("La conexión de Syncro Cliente no está configurada.");
    }

    /// <inheritdoc />
    public Task<int> RetryAsync(string agent, string file, string consecutive, string date, CancellationToken cancellationToken)
    {
        throw new InvalidOperationException("La conexión de Syncro Cliente no está configurada.");
    }

    /// <inheritdoc />
    public Task<int> SetSourceAsync(bool downloadFromFtp, CancellationToken cancellationToken)
    {
        throw new InvalidOperationException("La conexión de Syncro Cliente no está configurada.");
    }
}
