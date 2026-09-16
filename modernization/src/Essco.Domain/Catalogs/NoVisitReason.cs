namespace Essco.Domain.Catalogs;

public sealed record NoVisitReason
{
    public int Code { get; init; }
    public required string Reason { get; init; }

    public IReadOnlyCollection<string> Validate()
    {
        if (string.IsNullOrWhiteSpace(Reason)) return ["La razón es obligatoria."];
        return Reason.Trim().Length > 250 ? ["La razón no puede superar 250 caracteres."] : [];
    }
}
