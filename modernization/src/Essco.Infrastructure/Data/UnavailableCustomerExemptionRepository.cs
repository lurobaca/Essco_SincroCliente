using Essco.Application.Customers;
using Essco.Domain.Customers;
namespace Essco.Infrastructure.Data;

public sealed class UnavailableCustomerExemptionRepository : ICustomerExemptionRepository
{
    private static Exception Error() => new InvalidOperationException("El repositorio de exoneraciones no está configurado.");
    public ValueTask<IReadOnlyCollection<CustomerExemption>> ListAsync(string code, CancellationToken token) => ValueTask.FromResult<IReadOnlyCollection<CustomerExemption>>([]);
    public ValueTask<CustomerExemption?> GetAsync(long id, CancellationToken token) => ValueTask.FromResult<CustomerExemption?>(null);
    public ValueTask<long> SaveAsync(CustomerExemption x, CancellationToken token) => ValueTask.FromException<long>(Error());
    public ValueTask<bool> DeactivateAsync(long id, CancellationToken token) => ValueTask.FromException<bool>(Error());
    public ValueTask<IReadOnlyCollection<ExemptCabysCode>> ListCabysAsync(long id, CancellationToken token) => ValueTask.FromResult<IReadOnlyCollection<ExemptCabysCode>>([]);
    public ValueTask<bool> AddCabysAsync(long id, string code, string cabys, CancellationToken token) => ValueTask.FromException<bool>(Error());
    public ValueTask<bool> RemoveCabysAsync(long id, string cabys, CancellationToken token) => ValueTask.FromException<bool>(Error());
}
