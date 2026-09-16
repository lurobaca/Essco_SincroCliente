using Essco.Application.Catalogs;
using Essco.Domain.Catalogs;

namespace Essco.Infrastructure.Data;

public sealed class UnavailableBankRepository : IBankRepository
{
    public ValueTask<IReadOnlyCollection<CompanyBank>> ListAsync(CancellationToken token) => ValueTask.FromResult<IReadOnlyCollection<CompanyBank>>([]);
    public ValueTask CreateAsync(CompanyBank bank, CancellationToken token) => ValueTask.FromException(new InvalidOperationException("El catálogo no está configurado."));
    public ValueTask<bool> DeleteAsync(string code, CancellationToken token) => ValueTask.FromException<bool>(new InvalidOperationException("El catálogo no está configurado."));
}
