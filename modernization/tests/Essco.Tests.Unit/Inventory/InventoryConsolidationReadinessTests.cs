using Essco.Application.Inventory;
namespace Essco.Tests.Unit.Inventory;

public sealed class InventoryConsolidationReadinessTests
{
    [Fact]
    public void Empty_supplier_is_not_ready() =>
        Assert.False(InventoryConsolidationReadiness.AllCompleted([]));
    [Fact]
    public void Every_group_must_be_completed() =>
        Assert.False(InventoryConsolidationReadiness.AllCompleted([new("A", 1, 1), new("B", 1, 0)]));
    [Fact]
    public void Missing_control_is_not_ready() =>
        Assert.False(InventoryConsolidationReadiness.AllCompleted([new("A", 0, 0)]));
    [Fact]
    public void Duplicate_controls_are_not_ready() =>
        Assert.False(InventoryConsolidationReadiness.AllCompleted([new("A", 2, 2)]));
    [Fact]
    public void Duplicate_groups_are_not_ready() =>
        Assert.False(InventoryConsolidationReadiness.AllCompleted([new("A", 1, 1), new("a", 1, 1)]));
    [Fact]
    public void Completed_groups_are_ready() =>
        Assert.True(InventoryConsolidationReadiness.AllCompleted([new("A", 1, 1), new("B", 1, 1)]));
}
