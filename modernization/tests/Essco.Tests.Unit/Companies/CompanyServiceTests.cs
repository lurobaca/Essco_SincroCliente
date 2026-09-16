using Essco.Application.Companies;
using Essco.Domain.Companies;

namespace Essco.Tests.Unit.Companies;

public sealed class CompanyServiceTests
{
    [Fact]
    public async Task SaveAsync_DoesNotPersistInvalidCompany()
    {
        var repository = new Repository();
        var service = new CompanyService(repository);
        var invalid = Valid() with { Email = "not-an-email" };

        var result = await service.SaveAsync(invalid, CancellationToken.None);

        Assert.False(result.Succeeded);
        Assert.Null(repository.Saved);
    }

    [Fact]
    public async Task SaveAsync_PersistsValidCompany()
    {
        var repository = new Repository();
        var service = new CompanyService(repository);
        var company = Valid();

        var result = await service.SaveAsync(company, CancellationToken.None);

        Assert.True(result.Succeeded);
        Assert.Same(company, repository.Saved);
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

    private sealed class Repository : ICompanyRepository
    {
        public CompanyProfile? Saved { get; private set; }
        public ValueTask<CompanyProfile?> GetAsync(CancellationToken cancellationToken) => ValueTask.FromResult(Saved);
        public ValueTask SaveAsync(CompanyProfile company, CancellationToken cancellationToken)
        {
            Saved = company;
            return ValueTask.CompletedTask;
        }
    }
}
