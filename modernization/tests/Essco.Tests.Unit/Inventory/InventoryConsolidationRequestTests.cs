using Essco.Application.Inventory;
namespace Essco.Tests.Unit.Inventory;

public sealed class InventoryConsolidationRequestTests
{
    private static InventoryConsolidationRequest Valid => new(1, "P", "PX", "Responsable", "", 0);
    [Fact] public void Accepts_valid_request() => Assert.True(Valid.IsValid);
    [Theory]
    [InlineData("")]
    [InlineData("A")]
    [InlineData(" A ")]
    public void Requires_distinct_unified_group_convention(string group) => Assert.False((Valid with { Group = group }).IsValid);
    [Fact] public void Rejects_negative_threshold() => Assert.False((Valid with { Threshold = -1 }).IsValid);
    [Fact] public void Requires_responsible() => Assert.False((Valid with { Responsible = " " }).IsValid);
    [Fact] public void Requires_supplier() => Assert.False((Valid with { Supplier = "" }).IsValid);
    [Fact] public void Rejects_truncated_group() => Assert.False((Valid with { Group = new string('A', 51) }).IsValid);
}
