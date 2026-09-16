using Essco.Domain.Customers;

namespace Essco.Application.Customers;

public sealed record CustomerSearch(bool Approved, CustomerChangeState State, string? Term = null,
    bool SearchByName = false, string? AgentCode = null, DateOnly? From = null, DateOnly? To = null,
    int Page = 1, int PageSize = 50);
public sealed record CustomerSearchResult(IReadOnlyCollection<CustomerChangeRequest> Items, int Total);

public interface ICustomerChangeRepository
{
    ValueTask<CustomerSearchResult> SearchAsync(CustomerSearch search, CancellationToken cancellationToken);
    ValueTask<CustomerChangeRequest?> GetAsync(long id, CancellationToken cancellationToken);
    ValueTask<long> SaveAsync(CustomerChangeRequest request, CancellationToken cancellationToken);
    ValueTask<bool> ApproveAsync(long id, CancellationToken cancellationToken);
}

public sealed class CustomerChangeService(ICustomerChangeRepository repository)
{
    public ValueTask<CustomerSearchResult> SearchAsync(CustomerSearch search, CancellationToken cancellationToken) => repository.SearchAsync(search, cancellationToken);
    public ValueTask<CustomerChangeRequest?> GetAsync(long id, CancellationToken cancellationToken) => repository.GetAsync(id, cancellationToken);
    public async ValueTask<(bool Succeeded, long Id, IReadOnlyCollection<string> Errors)> SaveAsync(CustomerChangeRequest request, CancellationToken cancellationToken)
    {
        var errors = request.Validate();
        if (errors.Count > 0) return (false, request.Id, errors);
        return (true, await repository.SaveAsync(request, cancellationToken), []);
    }
    public ValueTask<bool> ApproveAsync(long id, CancellationToken cancellationToken) => repository.ApproveAsync(id, cancellationToken);
}
