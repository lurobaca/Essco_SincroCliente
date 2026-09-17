namespace Essco.Application.Inventory;
public interface IInventoryCrossingRepository
{
    ValueTask<bool> CrossAsync(int inventory, string group, decimal threshold, CancellationToken token);
}
