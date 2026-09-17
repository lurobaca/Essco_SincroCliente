namespace Essco.Application.Inventory;
public interface IInventoryCountCompletion
{
    ValueTask<bool> CompleteAsync(int inventory, string group, int number, CancellationToken token);
}
