namespace Essco.Application.Inventory;

public sealed record InventoryGroupCompletion(string Group, int Controls, int Completed);
public interface IInventoryConsolidationReadiness
{
    ValueTask<IReadOnlyCollection<InventoryGroupCompletion>> GetAsync(int inventory, string supplier, CancellationToken token);
}
public static class InventoryConsolidationReadiness
{
    public static bool AllCompleted(IEnumerable<InventoryGroupCompletion> groups)
    {
        var rows = groups.ToArray();
        return rows.Length > 0 && rows.All(x => !string.IsNullOrWhiteSpace(x.Group) && x.Controls == 1 && x.Completed == 1)
            && rows.Select(x => x.Group).Distinct(StringComparer.OrdinalIgnoreCase).Count() == rows.Length;
    }
}
