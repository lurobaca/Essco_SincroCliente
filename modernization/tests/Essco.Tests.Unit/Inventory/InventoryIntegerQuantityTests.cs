using Essco.Domain.Inventory;
namespace Essco.Tests.Unit.Inventory;

public sealed class InventoryIntegerQuantityTests
{
    [Theory]
    [InlineData("0", true)]
    [InlineData("2147483647", true)]
    [InlineData("2147483648", false)]
    [InlineData("0.5", false)]
    [InlineData("-1", false)]
    public void Count_respects_legacy_integer_storage(string quantity, bool valid)
    {
        var value = decimal.Parse(quantity, System.Globalization.CultureInfo.InvariantCulture);
        var count = new InventoryCount(1, "A", 6, "I", "Item", value, true, "P");
        Assert.Equal(valid, count.Validate().Count == 0);
    }
}
