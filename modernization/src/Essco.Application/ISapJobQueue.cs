using Essco.Domain;
using Essco.SapBridge.Contracts;

namespace Essco.Application;

public interface ISapJobQueue
{
    ValueTask<SapJob> EnqueueAsync(CreateSapJobRequest request, CancellationToken cancellationToken);
    ValueTask<SapJob?> ClaimNextAsync(CancellationToken cancellationToken);
    ValueTask CompleteAsync(Guid jobId, string externalId, CancellationToken cancellationToken);
    ValueTask FailAsync(Guid jobId, string sanitizedError, bool retryable, CancellationToken cancellationToken);
    ValueTask<IReadOnlyCollection<SapJob>> GetSnapshotAsync(CancellationToken cancellationToken);
}
