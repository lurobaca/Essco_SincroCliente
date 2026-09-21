using Essco.Application.HumanResources;
using Essco.Infrastructure.Data;

namespace Essco.Tests.Integration;

public sealed class SapEmployeeValidationTests
{
    [Fact]
    public async Task Configured_sap_connection_finds_known_customer()
    {
        var connection = Environment.GetEnvironmentVariable("ESSCO_TEST_SAP_CONNECTION");
        if (string.IsNullOrWhiteSpace(connection)) return;

        var repository = new SqlServerEmployeeRepository("", 30, "", connection);
        var result = await repository.ValidateSapCustomerAsync("C999-0304", default);

        Assert.Equal(ExternalValidationStatus.Valid, result.Status);
    }
}
