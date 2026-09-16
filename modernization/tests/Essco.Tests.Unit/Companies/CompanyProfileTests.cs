using Essco.Domain.Companies;

namespace Essco.Tests.Unit.Companies;

public sealed class CompanyProfileTests
{
    [Fact]
    public void Validate_AcceptsCompleteLegalEntity()
    {
        Assert.Empty(Valid().Validate());
    }

    [Fact]
    public void Validate_RejectsTaxIdWithWrongLength()
    {
        var company = Valid() with { TaxId = "123" };
        Assert.Contains(company.Validate(), error => error.Contains("10 dígitos", StringComparison.Ordinal));
    }

    [Fact]
    public void Validate_RejectsDiscountOutsideRange()
    {
        var company = Valid() with { MaximumDiscountPercent = 101m };
        Assert.Contains(company.Validate(), error => error.Contains("descuento", StringComparison.OrdinalIgnoreCase));
    }

    private static CompanyProfile Valid() => new()
    {
        TaxId = "3101123456",
        IdentificationType = CompanyIdentificationType.LegalEntity,
        LegalName = "Empresa de prueba",
        TradeName = "Empresa",
        Phone = "22223333",
        Email = "empresa@example.invalid",
        Address = "San José",
        ProvinceId = 1,
        CantonId = 1,
        DistrictId = 1,
        NeighborhoodId = 1,
        MaximumInvoiceLines = 100,
        MaximumDiscountPercent = 10,
        DiscountGrouping = DiscountGroupingType.CustomerGroup
    };
}
