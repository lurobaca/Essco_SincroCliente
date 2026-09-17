using Essco.Domain.Inventory;
namespace Essco.Application.Inventory;

public sealed record InventorySupplierLine(string Code, string Description, decimal Quantity,
    decimal? Stock, decimal? Cost, bool Invalid)
{
    // GuardaGrupo in Inv_Cruzar.vb uses stock minus counted quantity here.
    public decimal? Difference => Stock - Quantity;
    public decimal? Amount => Difference * Cost;
    public bool RequiresRecount(decimal threshold) =>
        Invalid || Amount is null || (Difference != 0 && Math.Abs(Amount.Value) >= threshold);
}

public static class InventorySupplierSummary
{
    public static IReadOnlyCollection<InventorySupplierLine> Calculate(int inventory, string supplier,
        IEnumerable<InventoryCount> counts, IEnumerable<InventoryItem> items)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(supplier);
        if (inventory <= 0) throw new ArgumentOutOfRangeException(nameof(inventory));
        var stock = items.Where(x => x.SupplierCode == supplier).ToLookup(x => x.Code);
        var third = counts.Where(x => x.InventoryId == inventory && x.SupplierCode == supplier && x.Number == 3)
            .ToLookup(x => x.ItemCode);
        return stock.Select(x => x.Key).Union(third.Select(x => x.Key)).OrderBy(x => x)
            .Select(code =>
            {
                var rows = third[code].ToArray();
                var masters = stock[code].ToArray();
                var item = masters.Length == 1 ? masters[0] : null;
                var invalid = item is null || rows.Length == 0 || rows.Any(x => x.Quantity < 0 || !x.Recount)
                    || rows.GroupBy(x => x.Group).Any(x => x.Count() != 1);
                return new InventorySupplierLine(code, item?.Description ?? rows.FirstOrDefault()?.Description ?? "",
                    rows.Sum(x => x.Quantity), item?.SystemStock, item?.UnitCost, invalid);
            }).ToArray();
    }
}
