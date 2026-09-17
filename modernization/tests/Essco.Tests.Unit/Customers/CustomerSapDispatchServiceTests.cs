using Essco.Application;
using Essco.Application.Customers;
using Essco.Domain;
using Essco.Domain.Customers;
using Essco.SapBridge.Contracts;
namespace Essco.Tests.Unit.Customers;

public sealed class CustomerSapDispatchServiceTests
{
    [Theory]
    [InlineData(CustomerChangeState.New, CustomerSapOperations.Create)]
    [InlineData(CustomerChangeState.Modified, CustomerSapOperations.Update)]
    [InlineData(CustomerChangeState.Close, CustomerSapOperations.Close)]
    public async Task Dispatch_MapsLegacyState(CustomerChangeState state, string expected)
    { var queue = new Queue(); var customer = Customer(state); var result = await new CustomerSapDispatchService(new Repository(customer), queue).DispatchAsync(7, "TEST", "user", CancellationToken.None); Assert.True(result.Succeeded); Assert.Equal(expected, queue.Request!.OperationType); Assert.Equal("customer-change:7:" + expected + ":" + CustomerRequestFingerprint.Compute(customer), queue.Request.IdempotencyKey); }
    [Fact] public async Task Dispatch_RejectsInternalCustomer() { var queue = new Queue(); var result = await new CustomerSapDispatchService(new Repository(Customer(CustomerChangeState.Internal)), queue).DispatchAsync(7, "TEST", "user", CancellationToken.None); Assert.False(result.Succeeded); Assert.Null(queue.Request); }
    private static CustomerChangeRequest Customer(CustomerChangeState state) => new() { Id = 7, Sequence = "7", Code = "C7", Name = "Cliente", TaxId = "3101123456", IdentificationType = 2, ProvinceId = 1, CantonId = 1, DistrictId = 1, NeighborhoodId = 1, RequestedAt = DateTime.UtcNow, State = state };
    private sealed class Repository(CustomerChangeRequest value) : ICustomerChangeRepository { public ValueTask<CustomerChangeRequest?> GetAsync(long id, CancellationToken token) => ValueTask.FromResult<CustomerChangeRequest?>(value); public ValueTask<CustomerSearchResult> SearchAsync(CustomerSearch s, CancellationToken t) => throw new NotSupportedException(); public ValueTask<long> SaveAsync(CustomerChangeRequest r, CancellationToken t) => throw new NotSupportedException(); public ValueTask<bool> ApproveAsync(long id, CancellationToken t) => throw new NotSupportedException(); }
    [Fact]
    public async Task InvalidCustomer_IsNotQueued()
    {
        var queue = new Queue();
        var result = await new CustomerSapDispatchService(new Repository(Customer(CustomerChangeState.New) with { TaxId = "" }), queue)
            .DispatchAsync(7, "TEST", "user", default);
        Assert.False(result.Succeeded);
        Assert.Null(queue.Request);
    }

    [Fact]
    public async Task InvalidId_IsNotQueued()
    {
        var queue = new Queue();
        var result = await new CustomerSapDispatchService(new Repository(Customer(CustomerChangeState.New)), queue)
            .DispatchAsync(-1, "TEST", "user", default);
        Assert.False(result.Succeeded);
        Assert.Null(queue.Request);
    }

    private sealed class Queue : ISapJobQueue
    { public CreateSapJobRequest? Request { get; private set; } public ValueTask<SapJob> EnqueueAsync(CreateSapJobRequest request, CancellationToken token) { Request = request; return ValueTask.FromResult(new SapJob { OperationType = request.OperationType, Company = request.Company, RequestedBy = request.RequestedBy, Payload = request.Payload }); } public ValueTask<SapJob?> ClaimNextAsync(CancellationToken t) => throw new NotSupportedException(); public ValueTask CompleteAsync(Guid id, string e, CancellationToken t) => throw new NotSupportedException(); public ValueTask FailAsync(Guid id, string e, bool r, CancellationToken t) => throw new NotSupportedException(); public ValueTask<IReadOnlyCollection<SapJob>> GetSnapshotAsync(CancellationToken t) => throw new NotSupportedException(); }
}
