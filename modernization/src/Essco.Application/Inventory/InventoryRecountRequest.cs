namespace Essco.Application.Inventory;

public sealed record InventoryRecountRequest(int Inventory, string Group, int Previous, IReadOnlyCollection<string> Items)
{
    public bool IsValid => Inventory > 0 && !string.IsNullOrWhiteSpace(Group) && Group.Trim().Length <= 50
        && Previous >= 3 && Previous < int.MaxValue && Items.Count > 0
        && Items.All(x => !string.IsNullOrWhiteSpace(x) && x.Trim().Length <= 100)
        && Items.Select(x => x.Trim()).Distinct(StringComparer.OrdinalIgnoreCase).Count() == Items.Count;
}
public interface IInventoryRecountRepository
{
    ValueTask<bool> CreateAsync(InventoryRecountRequest request, CancellationToken token);
}
