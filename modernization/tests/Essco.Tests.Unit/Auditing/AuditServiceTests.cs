using Essco.Application.Auditing;

namespace Essco.Tests.Unit.Auditing;

public sealed class AuditServiceTests
{
    [Fact]
    public async Task WriteAsync_SanitizesAndTruncatesText()
    {
        var sink = new Sink();
        var service = new AuditService(sink, TimeProvider.System);

        await service.WriteAsync(1, " user\r\n", "company", "operation", "entity", new string('x', 300),
            "success", "correlation", "127.0.0.1", CancellationToken.None);

        Assert.NotNull(sink.Item);
        Assert.Equal("user", sink.Item.Username);
        Assert.Equal(256, sink.Item.EntityId!.Length);
    }

    [Fact]
    public async Task WriteAsync_RequiresOperationAndCorrelation()
    {
        var service = new AuditService(new Sink(), TimeProvider.System);

        await Assert.ThrowsAsync<ArgumentException>(async () =>
            await service.WriteAsync(null, null, null, "", "entity", null, "success", "correlation", null, CancellationToken.None));
    }

    private sealed class Sink : IAuditSink
    {
        public AuditEvent? Item { get; private set; }
        public ValueTask WriteAsync(AuditEvent auditEvent, CancellationToken cancellationToken)
        {
            Item = auditEvent;
            return ValueTask.CompletedTask;
        }
    }
}
