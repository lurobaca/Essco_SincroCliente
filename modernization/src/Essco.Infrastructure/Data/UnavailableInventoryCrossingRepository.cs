using Essco.Application.Inventory;
namespace Essco.Infrastructure.Data;
public sealed class UnavailableInventoryCrossingRepository : IInventoryCrossingRepository
{
    public ValueTask<bool> CrossAsync(int inventory, string group, decimal threshold, CancellationToken token) => ValueTask.FromResult(false);
}
