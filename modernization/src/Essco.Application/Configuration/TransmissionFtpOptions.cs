namespace Essco.Application.Configuration;

/// <summary>
/// Configura el FTP de transmisiones directamente o mediante el XML heredado.
/// </summary>
public sealed class TransmissionFtpOptions
{
    public bool Enabled { get; init; }
    public bool EnableSsl { get; init; }
    public string Endpoint { get; init; } = "";
    public string Username { get; init; } = "";
    public string Password { get; init; } = "";
    public string LegacyConfigurationPath { get; init; } = "";
    public int TimeoutSeconds { get; init; } = 15;

    /// <summary>
    /// Valida los datos necesarios antes de habilitar la transmisión.
    /// </summary>
    public bool IsValid()
    {
        if (TimeoutSeconds is < 1 or > 120)
        {
            return false;
        }

        if (!Enabled)
        {
            return true;
        }

        if (!string.IsNullOrWhiteSpace(Endpoint))
        {
            return Uri.TryCreate(Endpoint, UriKind.Absolute, out Uri? uri) &&
                uri.Scheme == Uri.UriSchemeFtp &&
                string.IsNullOrEmpty(uri.UserInfo) &&
                string.IsNullOrEmpty(uri.Query) &&
                string.IsNullOrWhiteSpace(uri.Fragment) &&
                !string.IsNullOrWhiteSpace(Username) &&
                !string.IsNullOrWhiteSpace(Password);
        }

        return !string.IsNullOrWhiteSpace(LegacyConfigurationPath);
    }
}
