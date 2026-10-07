using Essco.Application.Billing;

namespace Essco.Infrastructure.Data;

/// <summary>
/// Mantiene inactivos los envíos cuando el FTP está apagado o su configuración falla.
/// </summary>
public sealed class UnavailableTransmissionSignalSender : ITransmissionSignalSender
{
    public bool IsConfigured => false;

    /// <inheritdoc />
    public Task SendAsync(string agent, CancellationToken cancellationToken)
    {
        throw new InvalidOperationException("El envío FTP de transmisiones no está disponible.");
    }
}
