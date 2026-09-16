using Essco.Domain.Customers;

namespace Essco.Tests.Unit.Customers;

public sealed class CustomerChangeRequestTests
{
    [Fact]
    public void Validate_AcceptsCompleteRequest() => Assert.Empty(Valid().Validate());

    [Fact]
    public void Validate_RejectsInvalidCoordinates()
    {
        var errors = Valid() with { Latitude = 91, Longitude = -181 };
        Assert.Equal(2, errors.Validate().Count(x => x.Contains("tud", StringComparison.Ordinal)));
    }

    [Fact]
    public void Validate_RejectsReversedExemptionDates()
    {
        var request = Valid() with { ExemptionIssuedOn = new(2026, 2, 1), ExemptionExpiresOn = new(2026, 1, 1) };
        Assert.Contains(request.Validate(), x => x.Contains("vencimiento", StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public void Validate_RejectsTaxIdThatDoesNotMatchType()
    {
        var request = Valid() with { IdentificationType = 1 };
        Assert.Contains(request.Validate(), x => x.Contains("9 dígitos", StringComparison.Ordinal));
    }

    private static CustomerChangeRequest Valid() => new()
    {
        Sequence = "1",
        Code = "C001",
        Name = "Cliente",
        TaxId = "3101123456",
        IdentificationType = 2,
        ProvinceId = 1,
        CantonId = 1,
        DistrictId = 1,
        NeighborhoodId = 1,
        RequestedAt = DateTime.UtcNow
    };
}
