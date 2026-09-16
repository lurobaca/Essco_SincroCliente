using Essco.Application.Customers;
using Essco.Domain.Customers;

namespace Essco.Infrastructure.Data;

public sealed class UnavailableCustomerChangeRepository : ICustomerChangeRepository
{
    public ValueTask<CustomerSearchResult> SearchAsync(CustomerSearch search, CancellationToken cancellationToken) => ValueTask.FromResult(new CustomerSearchResult([], 0));
    public ValueTask<CustomerChangeRequest?> GetAsync(long id, CancellationToken cancellationToken) => ValueTask.FromResult<CustomerChangeRequest?>(null);
    public ValueTask<long> SaveAsync(CustomerChangeRequest request, CancellationToken cancellationToken) => ValueTask.FromException<long>(new InvalidOperationException("El repositorio de clientes no está configurado."));
    public ValueTask<bool> ApproveAsync(long id, CancellationToken cancellationToken) => ValueTask.FromException<bool>(new InvalidOperationException("El repositorio de clientes no está configurado."));
}
