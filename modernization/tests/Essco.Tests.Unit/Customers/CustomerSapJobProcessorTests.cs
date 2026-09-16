using System.Text.Json;
using Essco.Application.Companies;
using Essco.Application.Customers;
using Essco.Domain.Customers;
using Essco.SapBridge.Contracts;
namespace Essco.Tests.Unit.Customers;

public sealed class CustomerSapJobProcessorTests
{
    [Fact]
    public async Task SuccessfulSapResult_ApprovesSqlRequest()
    { var repository = new Repository(Customer()); var result = await new CustomerSapJobProcessor(repository, new Geography(), new Gateway(new(true, "C1", null, false))).ProcessAsync(CustomerSapOperations.Create, JsonSerializer.Serialize(new CustomerSapPayload(1)), CancellationToken.None); Assert.True(result.Succeeded); Assert.True(repository.ApproveCalled); }
    [Fact]
    public async Task FailedSapResult_DoesNotApproveSqlRequest()
    { var repository = new Repository(Customer()); var result = await new CustomerSapJobProcessor(repository, new Geography(), new Gateway(new(false, null, "SAP error", true))).ProcessAsync(CustomerSapOperations.Create, JsonSerializer.Serialize(new CustomerSapPayload(1)), CancellationToken.None); Assert.False(result.Succeeded); Assert.False(repository.ApproveCalled); }
    [Fact]
    public async Task MismatchedOperation_IsRejectedBeforeSap()
    { var gateway = new Gateway(new(true, "C1", null, false)); var result = await new CustomerSapJobProcessor(new Repository(Customer()), new Geography(), gateway).ProcessAsync(CustomerSapOperations.Close, JsonSerializer.Serialize(new CustomerSapPayload(1)), CancellationToken.None); Assert.False(result.Succeeded); Assert.False(gateway.Called); }
    private static CustomerChangeRequest Customer() => new() { Id = 1, Sequence = "1", Code = "C1", Name = "Cliente", TaxId = "3101123456", IdentificationType = 2, ProvinceId = 1, CantonId = 1, DistrictId = 1, NeighborhoodId = 1, RequestedAt = DateTime.UtcNow, State = CustomerChangeState.New };
    private sealed class Gateway(SapProcessingResult result) : ISapCustomerGateway { public bool Called { get; private set; } public ValueTask<SapProcessingResult> ExecuteAsync(string op, SapCustomerData data, CancellationToken token) { Called = true; return ValueTask.FromResult(result); } }
    private sealed class Repository(CustomerChangeRequest customer) : ICustomerChangeRepository
    { public bool ApproveCalled { get; private set; } public ValueTask<CustomerChangeRequest?> GetAsync(long id, CancellationToken t) => ValueTask.FromResult<CustomerChangeRequest?>(customer); public ValueTask<bool> ApproveAsync(long id, CancellationToken t) { ApproveCalled = true; return ValueTask.FromResult(true); } public ValueTask<CustomerSearchResult> SearchAsync(CustomerSearch s, CancellationToken t) => throw new NotSupportedException(); public ValueTask<long> SaveAsync(CustomerChangeRequest r, CancellationToken t) => throw new NotSupportedException(); }
    private sealed class Geography : IGeographyRepository
    { private static readonly IReadOnlyCollection<LocationOption> Values = [new(1, "Lugar")]; public ValueTask<IReadOnlyCollection<LocationOption>> GetProvincesAsync(CancellationToken t) => ValueTask.FromResult(Values); public ValueTask<IReadOnlyCollection<LocationOption>> GetCantonsAsync(int p, CancellationToken t) => ValueTask.FromResult(Values); public ValueTask<IReadOnlyCollection<LocationOption>> GetDistrictsAsync(int p, int c, CancellationToken t) => ValueTask.FromResult(Values); public ValueTask<IReadOnlyCollection<LocationOption>> GetNeighborhoodsAsync(int p, int c, int d, CancellationToken t) => ValueTask.FromResult(Values); }
}
