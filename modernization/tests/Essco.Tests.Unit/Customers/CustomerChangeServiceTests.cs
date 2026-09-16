using Essco.Application.Customers;
using Essco.Domain.Customers;

namespace Essco.Tests.Unit.Customers;

public sealed class CustomerChangeServiceTests
{
    [Fact]
    public async Task SaveAsync_DoesNotCallRepository_WhenInvalid()
    {
        var repository = new Repository();
        var result = await new CustomerChangeService(repository).SaveAsync(new CustomerChangeRequest
        { Sequence="", Code="", Name="", TaxId="", IdentificationType=2, RequestedAt=DateTime.UtcNow }, CancellationToken.None);
        Assert.False(result.Succeeded);
        Assert.Equal(0, repository.SaveCalls);
    }

    [Fact]
    public async Task SaveAsync_ReturnsGeneratedId()
    {
        var repository = new Repository();
        var request = new CustomerChangeRequest { Sequence="1",Code="C1",Name="Cliente",TaxId="3101123456",IdentificationType=2,ProvinceId=1,CantonId=1,DistrictId=1,NeighborhoodId=1,RequestedAt=DateTime.UtcNow };
        var result = await new CustomerChangeService(repository).SaveAsync(request,CancellationToken.None);
        Assert.True(result.Succeeded);
        Assert.Equal(42,result.Id);
    }

    private sealed class Repository : ICustomerChangeRepository
    {
        public int SaveCalls { get; private set; }
        public ValueTask<CustomerSearchResult> SearchAsync(CustomerSearch search,CancellationToken token)=>ValueTask.FromResult(new CustomerSearchResult([],0));
        public ValueTask<CustomerChangeRequest?> GetAsync(long id,CancellationToken token)=>ValueTask.FromResult<CustomerChangeRequest?>(null);
        public ValueTask<long> SaveAsync(CustomerChangeRequest request,CancellationToken token){SaveCalls++;return ValueTask.FromResult(42L);}
        public ValueTask<bool> ApproveAsync(long id,CancellationToken token)=>ValueTask.FromResult(true);
    }
}
