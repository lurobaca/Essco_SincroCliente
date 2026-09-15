using System.Collections.Concurrent;
using System.Threading.Channels;
using Essco.Application;
using Essco.Domain;
using Essco.SapBridge.Contracts;

namespace Essco.Infrastructure;

public sealed class InMemorySapJobQueue : ISapJobQueue
{
    private readonly Channel<SapJob> _channel = Channel.CreateUnbounded<SapJob>();
    private readonly ConcurrentDictionary<Guid, SapJob> _jobs = new();
    private readonly ConcurrentDictionary<string, Guid> _idempotencyKeys = new(StringComparer.Ordinal);

    public async ValueTask<SapJob> EnqueueAsync(CreateSapJobRequest request, CancellationToken cancellationToken)
    {
        if (_idempotencyKeys.TryGetValue(request.IdempotencyKey, out var existingId))
            return _jobs[existingId];

        var job = new SapJob
        {
            OperationType = request.OperationType,
            Company = request.Company,
            RequestedBy = request.RequestedBy,
            Payload = request.Payload
        };

        if (!_idempotencyKeys.TryAdd(request.IdempotencyKey, job.Id))
            return _jobs[_idempotencyKeys[request.IdempotencyKey]];

        _jobs[job.Id] = job;
        await _channel.Writer.WriteAsync(job, cancellationToken);
        return job;
    }

    public async ValueTask<SapJob?> DequeueAsync(CancellationToken cancellationToken) =>
        await _channel.Reader.ReadAsync(cancellationToken);

    public IReadOnlyCollection<SapJob> GetSnapshot() =>
        _jobs.Values.OrderByDescending(job => job.CreatedAt).ToArray();
}
