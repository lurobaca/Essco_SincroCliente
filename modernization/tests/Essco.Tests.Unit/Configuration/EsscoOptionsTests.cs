using Essco.Application.Configuration;

namespace Essco.Tests.Unit.Configuration;

public sealed class EsscoOptionsTests
{
    [Fact]
    public void Validate_AllowsDisabledAdaptersWithoutSecrets()
    {
        var options = new EsscoOptions();

        Assert.Empty(options.Validate());
    }

    [Fact]
    public void Validate_RejectsEnabledDatabaseWithoutConnectionName()
    {
        var options = new EsscoOptions
        {
            SqlServer = new DatabaseEndpointOptions { Enabled = true, ConnectionStringName = "" }
        };

        Assert.Contains(options.Validate(), error => error.Contains("ConnectionStringName", StringComparison.Ordinal));
    }

    [Fact]
    public void Validate_RejectsInMemoryTransportWhenSapIsEnabled()
    {
        var options = new EsscoOptions
        {
            SapBridge = new SapBridgeOptions { Enabled = true, Transport = "InMemory", Endpoint = "local" }
        };

        Assert.Contains(options.Validate(), error => error.Contains("InMemory", StringComparison.Ordinal));
    }

    [Fact]
    public void Validate_AllowsSqlTransportWithoutEndpoint()
    {
        var options = new EsscoOptions { SapBridge = new SapBridgeOptions { Enabled = true, Transport = "SqlServer" } };
        Assert.DoesNotContain(options.Validate(), error => error.Contains("Endpoint", StringComparison.Ordinal));
    }

    [Fact]
    public void Validate_RejectsEnabledSapWithoutCredentials()
    {
        var options = new EsscoOptions { Sap = new SapCompanyOptions { Enabled = true } };
        Assert.Contains(options.Validate(), error => error.Contains("Sap:Server", StringComparison.Ordinal));
        Assert.Contains(options.Validate(), error => error.Contains("DatabaseServerType", StringComparison.Ordinal));
    }
}
