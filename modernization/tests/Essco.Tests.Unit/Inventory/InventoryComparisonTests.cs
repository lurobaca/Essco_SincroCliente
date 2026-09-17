using Essco.Application.Inventory;
using Essco.Domain.Inventory;
namespace Essco.Tests.Unit.Inventory;
public sealed class InventoryComparisonTests
{
    [Theory]
    [InlineData(10, 10, false)]
    [InlineData(10, 12, true)]
    [InlineData(12, 10, true)]
    [InlineData(10, 11, false)]
    public void Threshold_is_inclusive_and_symmetric(int first, int second, bool recount)
    {
        var line = new InventoryComparisonLine("X", "", first, second, 5);
        Assert.Equal(recount, line.RequiresRecount(10));
    }
    [Fact]
    public void Missing_count_is_not_treated_as_zero()
    {
        var result = InventoryComparison.Compare([new InventoryCount(1, "A", 1, "X", "", 0, false, "P")],
            [new InventoryItem("X", "", "P", 0, 0, 5, 0, 0)], "A", 1, 2).Single();
        Assert.True(result.Incomplete);
        Assert.True(result.RequiresRecount(1000));
        Assert.Null(result.Second);
    }
}
