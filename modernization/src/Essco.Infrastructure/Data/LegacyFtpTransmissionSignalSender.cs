using System.Net;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using Essco.Application.Billing;
using Essco.Application.Configuration;
using Microsoft.Data.SqlClient;

namespace Essco.Infrastructure.Data;

/// <summary>
/// Publica la misma señal vacía que genera WinForms para que Syncro Server la recoja.
/// </summary>
public sealed class LegacyFtpTransmissionSignalSender : ITransmissionSignalSender
{
    private readonly Uri? ftpBaseUri;
    private readonly NetworkCredential? credentials;
    private readonly TimeSpan timeout;
    private readonly bool enableSsl;

    /// <summary>
    /// Carga el XML heredado solo cuando el envío está habilitado y comprueba que su SQL
    /// corresponde a la base utilizada por la Web.
    /// </summary>
    public LegacyFtpTransmissionSignalSender(
        TransmissionFtpOptions options,
        string? sqlConnectionString,
        string contentRootPath)
    {
        timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
        enableSsl = options.EnableSsl;
        if (!options.Enabled)
        {
            return;
        }

        if (string.IsNullOrWhiteSpace(sqlConnectionString))
        {
            throw new InvalidOperationException("La transmisión requiere la conexión SQL de Syncro Cliente.");
        }

        string configurationPath = Path.IsPathRooted(options.LegacyConfigurationPath)
            ? options.LegacyConfigurationPath
            : Path.GetFullPath(Path.Combine(contentRootPath, options.LegacyConfigurationPath));

        var xmlSettings = new XmlReaderSettings
        {
            DtdProcessing = DtdProcessing.Prohibit,
            XmlResolver = null
        };
        using var reader = XmlReader.Create(configurationPath, xmlSettings);
        XDocument document = XDocument.Load(reader);
        XElement sqlNode = GetRequiredNode(document, "SQL_Sic_Local_Web");
        XElement ftpNode = GetRequiredNode(document, "FTP");

        string legacyDatabase = ReadRequiredValue(sqlNode, "dababase");
        string webDatabase = new SqlConnectionStringBuilder(sqlConnectionString).InitialCatalog;
        if (!string.Equals(legacyDatabase, webDatabase, StringComparison.OrdinalIgnoreCase))
        {
            throw new InvalidOperationException(
                "La base SQL del XML FTP no coincide con la base configurada para la Web.");
        }

        string ftpAddress = ReadRequiredValue(ftpNode, "FtpServer").TrimEnd('/') + "/";
        if (!Uri.TryCreate(ftpAddress, UriKind.Absolute, out Uri? parsedUri) ||
            parsedUri.Scheme != Uri.UriSchemeFtp)
        {
            throw new InvalidOperationException("El XML no contiene un destino FTP válido.");
        }

        ftpBaseUri = parsedUri;
        credentials = new NetworkCredential(
            ReadRequiredValue(ftpNode, "userFTP"),
            ReadRequiredValue(ftpNode, "passFTP", preserveWhitespace: true));
        IsConfigured = true;
    }

    public bool IsConfigured { get; }

    /// <summary>
    /// Envía una línea vacía a Revisame sin depender del directorio local de la PC WinForms.
    /// La carga FTP reemplaza el archivo remoto; no lo borra antes para evitar un intervalo vacío.
    /// </summary>
    public async Task SendAsync(string agent, CancellationToken cancellationToken)
    {
        if (!IsConfigured || ftpBaseUri is null || credentials is null)
        {
            throw new InvalidOperationException("El envío FTP de transmisiones no está habilitado.");
        }

        if (agent.Length is < 1 or > 10 || !agent.All(char.IsDigit))
        {
            throw new ArgumentException("El número de agente no es válido.", nameof(agent));
        }

        // FtpWebRequest mantiene el protocolo del Syncro Server heredado sin agregar dependencias.
#pragma warning disable SYSLIB0014
        var request = (FtpWebRequest)WebRequest.Create(
            new Uri(ftpBaseUri, $"Revisame/{agent}.mbg"));
#pragma warning restore SYSLIB0014
        request.Method = WebRequestMethods.Ftp.UploadFile;
        request.EnableSsl = enableSsl;
        request.Credentials = credentials;
        request.Proxy = null;
        request.KeepAlive = false;
        request.Timeout = (int)timeout.TotalMilliseconds;
        request.ReadWriteTimeout = (int)timeout.TotalMilliseconds;

        byte[] content = Encoding.Default.GetBytes(Environment.NewLine);
        request.ContentLength = content.Length;
        using CancellationTokenRegistration cancellation = cancellationToken.Register(request.Abort);
        await using (Stream requestStream = await request.GetRequestStreamAsync().WaitAsync(cancellationToken))
        {
            await requestStream.WriteAsync(content, cancellationToken);
        }

        using var response = (FtpWebResponse)await request.GetResponseAsync().WaitAsync(cancellationToken);
        if (response.StatusCode is not (FtpStatusCode.ClosingData or FtpStatusCode.CommandOK))
        {
            throw new IOException("El FTP no confirmó la recepción del archivo de señal.");
        }
    }

    /// <summary>
    /// Busca una única sección de configuración heredada sin aceptar XML ambiguo.
    /// </summary>
    private static XElement GetRequiredNode(XDocument document, string code)
    {
        XElement[] matches = document.Root?
            .Elements("name")
            .Where(node => (string?)node.Attribute("codigo") == code)
            .ToArray() ?? [];
        return matches.Length == 1
            ? matches[0]
            : throw new InvalidOperationException($"El XML debe contener una sección {code} única.");
    }

    /// <summary>
    /// Rechaza valores ausentes sin mostrar usuarios, contraseñas ni servidores en errores.
    /// </summary>
    private static string ReadRequiredValue(
        XElement node,
        string field,
        bool preserveWhitespace = false)
    {
        string? value = (string?)node.Element(field);
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new InvalidOperationException($"Falta el campo {field} en el XML heredado.");
        }

        return preserveWhitespace ? value : value.Trim();
    }
}
