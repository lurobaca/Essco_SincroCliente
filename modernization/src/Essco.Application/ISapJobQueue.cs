using Essco.Domain;
using Essco.SapBridge.Contracts;

namespace Essco.Application;

public interface ISapJobQueue
{
    ValueTask<SapJob> EnqueueAsync(CreateSapJobRequest request, CancellationToken cancellationToken);
    ValueTask<SapJob?> DequeueAsync(CancellationToken cancellationToken);
    IReadOnlyCollection<SapJob> GetSnapshot();
}
