using Essco.Application.Inventory;
using Essco.Domain.Inventory;
namespace Essco.Tests.Unit.Inventory;

public sealed class InventorySupplierSummaryTests
{
    [Fact]
    public void Uses_latest_count_per_original_group_and_excludes_unified_group()
    {
        var result = InventorySupplierSummary.Calculate(1, "P", [Count("A", 3),
            Count("A", 7) with { Number = 10 }, Count("B", 2), Count("PX", 50) with { Number = 4 }], [Item]).Single();
        Assert.Equal(9m, result.Quantity);
        Assert.False(result.Invalid);
    }
    private static InventoryItem Item => new("X", "Artículo", "P", 10, 0, 5, 0, 0);
    private static InventoryCount Count(string group, decimal quantity) => new(1, group, 3, "X", "Artículo", quantity, true, "P");
    [Fact]
    public void Sums_groups_and_excludes_other_inventories_suppliers_and_counts()
    {
        var result = InventorySupplierSummary.Calculate(1, "P", [Count("A", 3), Count("B", 5),
            Count("C", 99) with { InventoryId = 2 }, Count("D", 99) with { SupplierCode = "Q" },
            Count("E", 99) with { Number = 2 }], [Item]).Single();
        Assert.Equal(8m, result.Quantity);
        Assert.Equal(2m, result.Difference);
        Assert.Equal(10m, result.Amount);
        Assert.False(result.Invalid);
        Assert.True(result.RequiresRecount(10));
        Assert.False(result.RequiresRecount(11));
    }
    [Fact]
    public void Missing_count_is_invalid_even_when_system_stock_is_zero()
    {
        Assert.True(InventorySupplierSummary.Calculate(1, "P", [], [Item with { SystemStock = 0 }]).Single().Invalid);
    }
    [Fact]
    public void Duplicate_lines_in_same_group_are_invalid()
    {
        Assert.True(InventorySupplierSummary.Calculate(1, "P", [Count("A", 2), Count("A", 3)], [Item]).Single().Invalid);
    }
    [Fact]
    public void Unresolved_line_is_invalid()
    {
        Assert.True(InventorySupplierSummary.Calculate(1, "P", [Count("A", 0) with { Recount = false }], [Item]).Single().Invalid);
    }
    [Fact]
    public void Missing_master_is_not_treated_as_zero_cost()
    {
        var line = InventorySupplierSummary.Calculate(1, "P", [Count("A", 10)], []).Single();
        Assert.Null(line.Amount);
        Assert.True(line.RequiresRecount(1000));
    }
    [Fact]
    public void Equal_stock_needs_no_recount_at_zero_threshold()
    {
        Assert.False(InventorySupplierSummary.Calculate(1, "P", [Count("A", 10)], [Item]).Single().RequiresRecount(0));
    }
}
