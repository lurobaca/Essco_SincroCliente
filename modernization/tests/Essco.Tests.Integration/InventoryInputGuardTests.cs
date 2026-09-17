using Essco.Application.Inventory;
using Essco.Infrastructure.Data;
namespace Essco.Tests.Integration;

// These tests verify rejection before opening SQL; they are not database integration tests.
public sealed class InventoryInputGuardTests
{
    [Theory]
    [InlineData(0,0,0)] [InlineData(-1,0,0)]
    public async Task Close_rejects_invalid_input_before_connecting(int id,decimal entries,decimal exits)
    {
        var repository=new SqlServerInventoryRepository("invalid connection string",1);
        Assert.False(await repository.CloseAsync(id,entries,exits,CancellationToken.None));
    }
    [Fact]
    public async Task Consolidation_rejects_invalid_request_before_connecting()
    {
        var repository=new SqlServerInventoryConsolidationRepository("invalid connection string",1);
        Assert.False(await repository.CreateAsync(new(1,"P","A","User","",0),CancellationToken.None));
    }
    [Fact]
    public async Task Recount_rejects_empty_selection_before_connecting()
    {
        var repository=new SqlServerInventoryRecountRepository("invalid connection string",1);
        Assert.False(await repository.CreateAsync(new(1,"A",3,[]),CancellationToken.None));
    }
}
