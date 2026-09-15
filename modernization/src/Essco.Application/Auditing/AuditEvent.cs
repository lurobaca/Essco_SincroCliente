namespace Essco.Application.Auditing;

public sealed record AuditEvent(
    Guid EventId,
    DateTimeOffset OccurredAt,
    int? UserId,
    string? Username,
    string? Company,
    string Operation,
    string EntityType,
    string? EntityId,
    string Outcome,
    string CorrelationId,
    string? IpAddress);

public interface IAuditSink
{
    ValueTask WriteAsync(AuditEvent auditEvent, CancellationToken cancellationToken);
}

public sealed class AuditService(IAuditSink sink, TimeProvider timeProvider)
{
    public ValueTask WriteAsync(
        int? userId,
        string? username,
        string? company,
        string operation,
        string entityType,
        string? entityId,
        string outcome,
        string correlationId,
        string? ipAddress,
        CancellationToken cancellationToken)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(operation);
        ArgumentException.ThrowIfNullOrWhiteSpace(entityType);
        ArgumentException.ThrowIfNullOrWhiteSpace(outcome);
        ArgumentException.ThrowIfNullOrWhiteSpace(correlationId);

        var item = new AuditEvent(
            Guid.NewGuid(),
            timeProvider.GetUtcNow(),
            userId,
            Clean(username, 256),
            Clean(company, 128),
            Clean(operation, 128)!,
            Clean(entityType, 128)!,
            Clean(entityId, 256),
            Clean(outcome, 64)!,
            Clean(correlationId, 128)!,
            Clean(ipAddress, 64));
        return sink.WriteAsync(item, cancellationToken);
    }

    private static string? Clean(string? value, int maximumLength)
    {
        if (string.IsNullOrWhiteSpace(value)) return null;
        var clean = value.Trim().Replace("\r", "", StringComparison.Ordinal).Replace("\n", "", StringComparison.Ordinal);
        return clean.Length <= maximumLength ? clean : clean[..maximumLength];
    }
}
