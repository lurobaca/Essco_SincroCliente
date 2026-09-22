using Essco.Application.Inventory;
namespace Essco.Infrastructure.Data;

public sealed class UnavailableInventoryCountCompletion : IInventoryCountCompletion
{
    public ValueTask<bool> CompleteAsync(int inventory, string group, int number, CancellationToken token) => ValueTask.FromResult(false);
}
