namespace Essco.SapBridge.Contracts;

public sealed record CreateSapJobRequest(
    string OperationType,
    string Company,
    string RequestedBy,
    string Payload,
    string IdempotencyKey);

public sealed record SapJobResult(
    Guid JobId,
    string Status,
    string? ExternalId,
    string? Error);
