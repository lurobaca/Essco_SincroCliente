using Essco.Application.Auditing;

namespace Essco.Infrastructure.Data;

public sealed class UnavailableAuditSink : IAuditSink
{
    public ValueTask WriteAsync(AuditEvent auditEvent, CancellationToken cancellationToken) => ValueTask.CompletedTask;
}
