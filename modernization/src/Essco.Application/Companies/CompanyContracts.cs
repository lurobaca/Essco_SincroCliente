using Essco.Domain.Companies;

namespace Essco.Application.Companies;

public interface ICompanyRepository
{
    ValueTask<CompanyProfile?> GetAsync(CancellationToken cancellationToken);
    ValueTask SaveAsync(CompanyProfile company, CancellationToken cancellationToken);
}

public sealed record LocationOption(int Id, string Name);

public interface IGeographyRepository
{
    ValueTask<IReadOnlyCollection<LocationOption>> GetProvincesAsync(CancellationToken cancellationToken);
    ValueTask<IReadOnlyCollection<LocationOption>> GetCantonsAsync(int provinceId, CancellationToken cancellationToken);
    ValueTask<IReadOnlyCollection<LocationOption>> GetDistrictsAsync(int provinceId, int cantonId, CancellationToken cancellationToken);
    ValueTask<IReadOnlyCollection<LocationOption>> GetNeighborhoodsAsync(int provinceId, int cantonId, int districtId, CancellationToken cancellationToken);
}

public sealed class CompanyService(ICompanyRepository repository)
{
    public ValueTask<CompanyProfile?> GetAsync(CancellationToken cancellationToken) =>
        repository.GetAsync(cancellationToken);

    public async ValueTask<CompanySaveResult> SaveAsync(CompanyProfile company, CancellationToken cancellationToken)
    {
        var errors = company.Validate();
        if (errors.Count > 0) return new(false, errors);
        await repository.SaveAsync(company, cancellationToken);
        return new(true, []);
    }
}

public sealed record CompanySaveResult(bool Succeeded, IReadOnlyCollection<string> Errors);
