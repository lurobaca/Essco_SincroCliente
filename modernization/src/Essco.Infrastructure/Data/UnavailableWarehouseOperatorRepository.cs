using Essco.Application.Catalogs;
using Essco.Domain.Catalogs;

namespace Essco.Infrastructure.Data;

public sealed class UnavailableWarehouseOperatorRepository : IWarehouseOperatorRepository
{
    public ValueTask<IReadOnlyCollection<WarehouseOperator>> ListAsync(CancellationToken token) => ValueTask.FromResult<IReadOnlyCollection<WarehouseOperator>>([]);
    public ValueTask<bool> SaveAsync(WarehouseOperator warehouseOperator, bool isNew, string? newPassword, CancellationToken token) => ValueTask.FromException<bool>(new InvalidOperationException("El catálogo no está configurado."));
    public ValueTask<bool> DeleteAsync(string code, CancellationToken token) => ValueTask.FromException<bool>(new InvalidOperationException("El catálogo no está configurado."));
}
