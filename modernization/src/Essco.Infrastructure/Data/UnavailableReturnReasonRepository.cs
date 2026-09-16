using Essco.Application.Catalogs;
using Essco.Domain.Catalogs;
namespace Essco.Infrastructure.Data;

public sealed class UnavailableReturnReasonRepository : IReturnReasonRepository
{ public ValueTask<IReadOnlyCollection<ReturnReason>> ListAsync(CancellationToken t) => ValueTask.FromResult<IReadOnlyCollection<ReturnReason>>([]); public ValueTask<IReadOnlyCollection<WarehouseOption>> ListWarehousesAsync(CancellationToken t) => ValueTask.FromResult<IReadOnlyCollection<WarehouseOption>>([]); public ValueTask<int> SaveAsync(ReturnReason r, CancellationToken t) => ValueTask.FromException<int>(new InvalidOperationException("El catálogo no está configurado.")); public ValueTask<bool> DeleteAsync(int c, CancellationToken t) => ValueTask.FromException<bool>(new InvalidOperationException("El catálogo no está configurado.")); }
