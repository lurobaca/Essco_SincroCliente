using Essco.Domain.Catalogs;
namespace Essco.Application.Catalogs;

public interface IReturnReasonRepository
{
    ValueTask<IReadOnlyCollection<ReturnReason>> ListAsync(CancellationToken token);
    ValueTask<int> SaveAsync(ReturnReason reason, CancellationToken token);
    ValueTask<bool> DeleteAsync(int code, CancellationToken token);
    ValueTask<IReadOnlyCollection<WarehouseOption>> ListWarehousesAsync(CancellationToken token);
}
public sealed class ReturnReasonService(IReturnReasonRepository repository)
{
    public ValueTask<IReadOnlyCollection<ReturnReason>> ListAsync(CancellationToken token) => repository.ListAsync(token);
    public ValueTask<IReadOnlyCollection<WarehouseOption>> ListWarehousesAsync(CancellationToken token) => repository.ListWarehousesAsync(token);
    public async ValueTask<(bool Succeeded, int Code, IReadOnlyCollection<string> Errors)> SaveAsync(ReturnReason reason, CancellationToken token) { var errors = reason.Validate(); return errors.Count > 0 ? (false, reason.Code, errors) : (true, await repository.SaveAsync(reason, token), []); }
    public ValueTask<bool> DeleteAsync(int code, CancellationToken token) => repository.DeleteAsync(code, token);
}
