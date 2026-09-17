using Essco.Domain.Liquidations;
using Essco.Infrastructure.Data;
namespace Essco.Tests.Integration;
// Checks guards before SQL is opened; does not validate the SQL transaction itself.
public sealed class LiquidationInputGuardTests
{
    [Fact]
    public async Task Recalculation_rejects_unknown_kind_without_connecting()
    {
        var repository=new SqlServerLiquidationRepository("invalid connection string",1,"SAP");
        Assert.False(await repository.RecalculateAsync((LiquidationKind)99,1,default));
    }
    [Fact]
    public async Task Recalculation_rejects_invalid_number_without_connecting()
    {
        var repository=new SqlServerLiquidationRepository("invalid connection string",1,"SAP");
        Assert.False(await repository.RecalculateAsync(LiquidationKind.Agents,0,default));
    }
}
