namespace Essco.Domain;

public enum SapJobStatus
{
    Pending,
    Processing,
    Completed,
    RetryableFailure,
    PermanentFailure,
    Cancelled
}

public sealed class SapJob
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public required string OperationType { get; init; }
    public required string Company { get; init; }
    public required string RequestedBy { get; init; }
    public required string Payload { get; init; }
    public SapJobStatus Status { get; private set; } = SapJobStatus.Pending;
    public int Attempts { get; private set; }
    public DateTimeOffset CreatedAt { get; init; } = DateTimeOffset.UtcNow;
    public DateTimeOffset? ProcessedAt { get; private set; }
    public string? ExternalId { get; private set; }
    public string? SanitizedError { get; private set; }

    public void Start()
    {
        if (Status is not (SapJobStatus.Pending or SapJobStatus.RetryableFailure))
            throw new InvalidOperationException($"El trabajo {Id} no puede procesarse desde {Status}.");

        Status = SapJobStatus.Processing;
        Attempts++;
    }

    public void Complete(string externalId)
    {
        if (Status != SapJobStatus.Processing)
            throw new InvalidOperationException($"El trabajo {Id} no está en proceso.");

        ExternalId = externalId;
        SanitizedError = null;
        ProcessedAt = DateTimeOffset.UtcNow;
        Status = SapJobStatus.Completed;
    }

    public void Fail(string sanitizedError, bool retryable)
    {
        if (Status != SapJobStatus.Processing)
            throw new InvalidOperationException($"El trabajo {Id} no está en proceso.");

        SanitizedError = sanitizedError;
        ProcessedAt = DateTimeOffset.UtcNow;
        Status = retryable ? SapJobStatus.RetryableFailure : SapJobStatus.PermanentFailure;
    }

    public static SapJob Restore(Guid id, string operationType, string company, string requestedBy,
        string payload, SapJobStatus status, int attempts, DateTimeOffset createdAt,
        DateTimeOffset? processedAt, string? externalId, string? sanitizedError)
    {
        return new SapJob
        {
            Id = id,
            OperationType = operationType,
            Company = company,
            RequestedBy = requestedBy,
            Payload = payload,
            Status = status,
            Attempts = attempts,
            CreatedAt = createdAt,
            ProcessedAt = processedAt,
            ExternalId = externalId,
            SanitizedError = sanitizedError
        };
    }
}
