using Essco.Application.Inventory;
namespace Essco.Tests.Unit.Inventory;

public sealed class InventoryRecountRequestTests
{
    [Theory]
    [InlineData(3)]
    [InlineData(4)]
    [InlineData(5)]
    [InlineData(6)]
    [InlineData(100)]
    public void Allows_successive_recounts(int previous) =>
        Assert.True(new InventoryRecountRequest(1, "A", previous, ["X"]).IsValid);
    [Theory]
    [InlineData(0)]
    [InlineData(2)]
    [InlineData(int.MaxValue)]
    public void Rejects_invalid_predecessor(int previous) =>
        Assert.False(new InventoryRecountRequest(1, "A", previous, ["X"]).IsValid);
    [Fact]
    public void Requires_selection() =>
        Assert.False(new InventoryRecountRequest(1, "A", 3, []).IsValid);
    [Fact]
    public void Rejects_duplicate_codes() =>
        Assert.False(new InventoryRecountRequest(1, "A", 3, ["X", " x "]).IsValid);
    [Fact]
    public void Rejects_empty_group() =>
        Assert.False(new InventoryRecountRequest(1, " ", 3, ["X"]).IsValid);
}
