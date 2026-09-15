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
}
