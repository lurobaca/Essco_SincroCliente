using Essco.Domain.Catalogs;

namespace Essco.Application.Catalogs;

public sealed record WarehouseWriteResult(bool Succeeded, string? Error = null);

public interface IWarehouseRepository
{
    ValueTask<IReadOnlyCollection<PickingWarehouse>> ListAsync(CancellationToken token);
    ValueTask<int> NextIdAsync(CancellationToken token);
    ValueTask<WarehouseWriteResult> SaveAsync(PickingWarehouse warehouse, bool isNew, CancellationToken token);
    ValueTask<WarehouseWriteResult> DeleteAsync(int id, CancellationToken token);
}

public sealed class WarehouseService(IWarehouseRepository repository)
{
    public ValueTask<IReadOnlyCollection<PickingWarehouse>> ListAsync(CancellationToken token) => repository.ListAsync(token);
    public ValueTask<int> NextIdAsync(CancellationToken token) => repository.NextIdAsync(token);

    public async ValueTask<WarehouseWriteResult> SaveAsync(PickingWarehouse warehouse, bool isNew, CancellationToken token)
    {
        var errors = warehouse.Validate();
        return errors.Count > 0
            ? new WarehouseWriteResult(false, string.Join(" ", errors))
            : await repository.SaveAsync(warehouse, isNew, token);
    }

    public ValueTask<WarehouseWriteResult> DeleteAsync(int id, CancellationToken token) => repository.DeleteAsync(id, token);
}
