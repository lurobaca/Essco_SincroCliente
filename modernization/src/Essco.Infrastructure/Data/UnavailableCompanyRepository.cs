using Essco.Application.Companies;
using Essco.Domain.Companies;

namespace Essco.Infrastructure.Data;

public sealed class UnavailableCompanyRepository : ICompanyRepository
{
    public ValueTask<CompanyProfile?> GetAsync(CancellationToken cancellationToken) => ValueTask.FromResult<CompanyProfile?>(null);
    public ValueTask SaveAsync(CompanyProfile company, CancellationToken cancellationToken) =>
        ValueTask.FromException(new InvalidOperationException("El repositorio de empresas no está configurado."));
}
