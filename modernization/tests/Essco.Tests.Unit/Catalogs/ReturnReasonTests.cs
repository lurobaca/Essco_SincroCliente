using Essco.Application.Catalogs;
using Essco.Domain.Catalogs;
namespace Essco.Tests.Unit.Catalogs;
public sealed class ReturnReasonTests
{
 [Fact]public void Validate_RequiresDescriptionAndWarehouse(){var errors=new ReturnReason{Description="",WarehouseCode=""}.Validate();Assert.Equal(2,errors.Count);}
 [Fact]public async Task Service_DoesNotPersistInvalidReason(){var repository=new Repository();var result=await new ReturnReasonService(repository).SaveAsync(new(){Description="",WarehouseCode="01"},CancellationToken.None);Assert.False(result.Succeeded);Assert.False(repository.Saved);}
 private sealed class Repository:IReturnReasonRepository{public bool Saved{get;private set;}public ValueTask<int> SaveAsync(ReturnReason r,CancellationToken t){Saved=true;return ValueTask.FromResult(1);}public ValueTask<IReadOnlyCollection<ReturnReason>> ListAsync(CancellationToken t)=>throw new NotSupportedException();public ValueTask<bool> DeleteAsync(int c,CancellationToken t)=>throw new NotSupportedException();public ValueTask<IReadOnlyCollection<WarehouseOption>> ListWarehousesAsync(CancellationToken t)=>throw new NotSupportedException();}
}
