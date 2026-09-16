using Essco.Application.Catalogs;
using Essco.Domain.Catalogs;

namespace Essco.Infrastructure.Data;

public sealed class UnavailableSalesAgentRepository : ISalesAgentRepository
{
    public ValueTask<IReadOnlyCollection<SalesAgent>> ListAsync(string? position, CancellationToken token) => ValueTask.FromResult<IReadOnlyCollection<SalesAgent>>([]);
    public ValueTask<bool> SaveAsync(SalesAgent agent, bool isNew, CancellationToken token) => ValueTask.FromException<bool>(new InvalidOperationException("El catálogo no está configurado."));
    public ValueTask<bool> DeleteAsync(string code, CancellationToken token) => ValueTask.FromException<bool>(new InvalidOperationException("El catálogo no está configurado."));
}
