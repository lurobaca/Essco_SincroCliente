using Essco.Application.Catalogs;
using Essco.Domain.Catalogs;

namespace Essco.Infrastructure.Data;

public sealed class UnavailableNoVisitReasonRepository : INoVisitReasonRepository
{
    public ValueTask<IReadOnlyCollection<NoVisitReason>> ListAsync(CancellationToken token) => ValueTask.FromResult<IReadOnlyCollection<NoVisitReason>>([]);
    public ValueTask<int> SaveAsync(NoVisitReason reason, CancellationToken token) => ValueTask.FromException<int>(new InvalidOperationException("El catálogo no está configurado."));
    public ValueTask<bool> DeleteAsync(int code, CancellationToken token) => ValueTask.FromException<bool>(new InvalidOperationException("El catálogo no está configurado."));
}
