using Essco.Domain;
using Essco.Infrastructure;
using Essco.SapBridge.Contracts;
namespace Essco.Tests.Integration;

public sealed class SapJobQueueTests
{
    [Fact]
    public async Task Enqueue_IsIdempotent()
    { var queue = new InMemorySapJobQueue(); var request = new CreateSapJobRequest("CustomerCreate", "TEST", "user", "{}", "customer:1"); var first = await queue.EnqueueAsync(request, CancellationToken.None); var second = await queue.EnqueueAsync(request, CancellationToken.None); Assert.Equal(first.Id, second.Id); }
    [Fact]
    public async Task ClaimAndComplete_PersistTransition()
    { var queue = new InMemorySapJobQueue(); var created = await queue.EnqueueAsync(new("CustomerCreate", "TEST", "user", "{}", "customer:2"), CancellationToken.None); var claimed = await queue.ClaimNextAsync(CancellationToken.None); Assert.Equal(SapJobStatus.Processing, claimed!.Status); await queue.CompleteAsync(created.Id, "SAP-C1", CancellationToken.None); var snapshot = await queue.GetSnapshotAsync(CancellationToken.None); Assert.Equal(SapJobStatus.Completed, snapshot.Single().Status); }
}
