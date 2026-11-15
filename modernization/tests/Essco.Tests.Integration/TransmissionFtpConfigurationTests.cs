using Essco.Application.Configuration;
using Essco.Infrastructure.Data;

namespace Essco.Tests.Integration;

/// <summary>
/// Comprueba que el emisor no mezcle una base de pruebas con otro XML FTP.
/// </summary>
public sealed class TransmissionFtpConfigurationTests
{
    [Fact]
    public void DisabledSender_DoesNotReadLegacyXml()
    {
        var sender = new LegacyFtpTransmissionSignalSender(
            new TransmissionFtpOptions
            {
                Enabled = false,
                LegacyConfigurationPath = "archivo-inexistente.xml"
            },
            null,
            Path.GetTempPath());

        Assert.False(sender.IsConfigured);
    }

    [Fact]
    public void EnabledSender_RejectsDifferentSqlDatabase()
    {
        string filePath = Path.GetTempFileName();
        try
        {
            File.WriteAllText(filePath, """
                <Conexiones>
                  <name codigo="SQL_Sic_Local_Web"><dababase>Produccion</dababase></name>
                  <name codigo="FTP">
                    <FtpServer>ftp://localhost/</FtpServer>
                    <userFTP>prueba</userFTP>
                    <passFTP>prueba</passFTP>
                  </name>
                </Conexiones>
                """);

            var options = new TransmissionFtpOptions
            {
                Enabled = true,
                LegacyConfigurationPath = filePath
            };

            Assert.Throws<InvalidOperationException>(() =>
                new LegacyFtpTransmissionSignalSender(
                    options,
                    "Server=localhost;Database=Pruebas;Integrated Security=true",
                    Path.GetTempPath()));
        }
        finally
        {
            File.Delete(filePath);
        }
    }

    [Fact]
    public void DirectFtp_UsesWebSqlWithoutLegacyXml()
    {
        var options = new TransmissionFtpOptions
        {
            Enabled = true,
            EnableSsl = true,
            Endpoint = "ftp://localhost/essco-pruebas/",
            Username = "operador-prueba",
            Password = "clave-de-prueba"
        };

        var sender = new LegacyFtpTransmissionSignalSender(
            options,
            "Server=localhost;Database=Sic_Local_Web_Pruebas;Integrated Security=true",
            Path.GetTempPath());

        Assert.True(options.IsValid());
        Assert.True(sender.IsConfigured);
    }

    [Fact]
    public void DirectFtp_RejectsMissingPassword()
    {
        var options = new TransmissionFtpOptions
        {
            Enabled = true,
            Endpoint = "ftp://localhost/essco-pruebas/",
            Username = "operador-prueba"
        };

        Assert.False(options.IsValid());
    }
}
