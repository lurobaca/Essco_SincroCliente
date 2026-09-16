using Essco.Domain.Customers;

namespace Essco.Application.Customers;

public interface ICustomerExemptionRepository
{
    ValueTask<IReadOnlyCollection<CustomerExemption>> ListAsync(string customerCode, CancellationToken cancellationToken);
    ValueTask<CustomerExemption?> GetAsync(long id, CancellationToken cancellationToken);
    ValueTask<long> SaveAsync(CustomerExemption exemption, CancellationToken cancellationToken);
    ValueTask<bool> DeactivateAsync(long id, CancellationToken cancellationToken);
    ValueTask<IReadOnlyCollection<ExemptCabysCode>> ListCabysAsync(long exemptionId, CancellationToken cancellationToken);
    ValueTask<bool> AddCabysAsync(long exemptionId, string customerCode, string cabysCode, CancellationToken cancellationToken);
    ValueTask<bool> RemoveCabysAsync(long exemptionId, string cabysCode, CancellationToken cancellationToken);
}

public sealed class CustomerExemptionService(ICustomerExemptionRepository repository)
{
    public ValueTask<IReadOnlyCollection<CustomerExemption>> ListAsync(string code, CancellationToken token) => repository.ListAsync(code, token);
    public ValueTask<CustomerExemption?> GetAsync(long id, CancellationToken token) => repository.GetAsync(id, token);
    public async ValueTask<(bool Succeeded, long Id, IReadOnlyCollection<string> Errors)> SaveAsync(CustomerExemption exemption, CancellationToken token)
    { var errors = exemption.Validate(); return errors.Count > 0 ? (false, exemption.Id, errors) : (true, await repository.SaveAsync(exemption, token), []); }
    public ValueTask<bool> DeactivateAsync(long id, CancellationToken token) => repository.DeactivateAsync(id, token);
    public ValueTask<IReadOnlyCollection<ExemptCabysCode>> ListCabysAsync(long id, CancellationToken token) => repository.ListCabysAsync(id, token);
    public ValueTask<bool> AddCabysAsync(long id, string code, string cabys, CancellationToken token)
    { if (string.IsNullOrWhiteSpace(cabys) || cabys.Trim().Length > 20) return ValueTask.FromResult(false); return repository.AddCabysAsync(id, code, cabys.Trim(), token); }
    public ValueTask<bool> RemoveCabysAsync(long id, string cabys, CancellationToken token) => repository.RemoveCabysAsync(id, cabys, token);
}
