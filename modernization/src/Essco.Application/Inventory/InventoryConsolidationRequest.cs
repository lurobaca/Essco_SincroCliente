namespace Essco.Application.Inventory;

public sealed record InventoryConsolidationRequest(int Inventory, string Supplier, string Group,
    string Responsible, string Companion, decimal Threshold)
{
    public bool IsValid => Inventory > 0 && !string.IsNullOrWhiteSpace(Supplier) && Supplier.Trim().Length <= 100
        && !string.IsNullOrWhiteSpace(Group) && Group.Trim().Length is > 1 and <= 50
        && !string.IsNullOrWhiteSpace(Responsible) && Responsible.Trim().Length <= 200
        && (Companion?.Length ?? 0) <= 200 && Threshold >= 0;
}
public interface IInventoryConsolidationRepository
{
    ValueTask<bool> CreateAsync(InventoryConsolidationRequest request, CancellationToken token);
}
