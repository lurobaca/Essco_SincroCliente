using Essco.Domain.Inventory;
namespace Essco.Application.Inventory;

public sealed record InventoryComparisonLine(string Code, string Description, decimal? First, decimal? Second, decimal? Cost)
{
    public decimal? Difference => First - Second;
    public decimal? DifferenceAmount => Difference * Cost;
    public bool Incomplete => First is null || Second is null || Cost is null;
    public bool RequiresRecount(decimal threshold) =>
        Incomplete || (Difference != 0 && Math.Abs(DifferenceAmount!.Value) >= threshold);
}

public static class InventoryComparison
{
    public static IReadOnlyCollection<InventoryComparisonLine> Compare(
        IEnumerable<InventoryCount> counts, IEnumerable<InventoryItem> items, string group, int first, int second)
    {
        if (string.IsNullOrWhiteSpace(group) || first <= 0 || second <= 0 || first == second)
            throw new ArgumentException("Seleccione grupo y dos conteos diferentes.");
        var selected = counts.Where(x => x.Group == group && (x.Number == first || x.Number == second)).ToArray();
        var costs = items.ToDictionary(x => x.Code, StringComparer.Ordinal);
        return selected.GroupBy(x => x.ItemCode).OrderBy(x => x.Key).Select(rows =>
        {
            var a = rows.Where(x => x.Number == first).ToArray();
            var b = rows.Where(x => x.Number == second).ToArray();
            // A missing or duplicated row must not silently become a zero count.
            return new InventoryComparisonLine(rows.Key, rows.First().Description,
                a.Length == 1 ? a[0].Quantity : null, b.Length == 1 ? b[0].Quantity : null,
                costs.TryGetValue(rows.Key, out var item) ? item.UnitCost : null);
        }).ToArray();
    }
}
