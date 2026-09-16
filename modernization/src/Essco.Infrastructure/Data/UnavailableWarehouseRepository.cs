using Essco.Application.Catalogs;
using Essco.Domain.Catalogs;

namespace Essco.Infrastructure.Data;

public sealed class UnavailableWarehouseRepository : IWarehouseRepository
{
    public ValueTask<IReadOnlyCollection<PickingWarehouse>> ListAsync(CancellationToken token) => ValueTask.FromResult<IReadOnlyCollection<PickingWarehouse>>([]);
    public ValueTask<int> NextIdAsync(CancellationToken token) => ValueTask.FromResult(1);
    public ValueTask<WarehouseWriteResult> SaveAsync(PickingWarehouse warehouse, bool isNew, CancellationToken token) => ValueTask.FromException<WarehouseWriteResult>(new InvalidOperationException("El catálogo no está configurado."));
    public ValueTask<WarehouseWriteResult> DeleteAsync(int id, CancellationToken token) => ValueTask.FromException<WarehouseWriteResult>(new InvalidOperationException("El catálogo no está configurado."));
}
