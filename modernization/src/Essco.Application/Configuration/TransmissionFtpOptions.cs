namespace Essco.Application.Configuration;

/// <summary>
/// Permite usar el XML FTP de WinForms sin copiar credenciales al repositorio Web.
/// </summary>
public sealed class TransmissionFtpOptions
{
    public bool Enabled { get; init; }
    public bool EnableSsl { get; init; }
    public string LegacyConfigurationPath { get; init; } = "";
    public int TimeoutSeconds { get; init; } = 15;

    /// <summary>
    /// Valida los datos necesarios antes de habilitar la transmisión.
    /// </summary>
    public bool IsValid()
    {
        return TimeoutSeconds is >= 1 and <= 120 &&
            (!Enabled || !string.IsNullOrWhiteSpace(LegacyConfigurationPath));
    }
}
