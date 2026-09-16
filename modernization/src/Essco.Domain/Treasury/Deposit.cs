namespace Essco.Domain.Treasury;

public sealed record Deposit
{
    public int Consecutive { get; init; }
    public required string Number { get; init; }
    public DateOnly Date { get; init; }
    public required string Bank { get; init; }
    public decimal Amount { get; init; }
    public required string EmployeeCode { get; init; }
    public required string Notes { get; init; }
    public required string LiquidationNumber { get; init; }
    public required string LiquidationType { get; init; }
    public DateOnly AccountingDate { get; init; }
    public bool IsAnnulled { get; init; }
    public bool IsUploaded { get; init; }
    public bool HasReceipt { get; init; }

    public IReadOnlyCollection<string> Validate()
    {
        var errors = new List<string>();
        if (string.IsNullOrWhiteSpace(Number)) errors.Add("El número de depósito es obligatorio.");
        else if (Number.Trim().Length > 100) errors.Add("El número de depósito no puede superar 100 caracteres.");
        if (string.IsNullOrWhiteSpace(Bank)) errors.Add("El banco es obligatorio.");
        if (string.IsNullOrWhiteSpace(EmployeeCode)) errors.Add("El código de agente o chofer es obligatorio.");
        if (Amount <= 0) errors.Add("El monto debe ser mayor que cero.");
        if (LiquidationType is not ("AGENTES" or "CHOFERES")) errors.Add("El tipo de liquidación debe ser AGENTES o CHOFERES.");
        return errors;
    }
}

public sealed record DepositFilter(DateOnly? From = null, DateOnly? To = null, string? EmployeeCode = null, string? Number = null, int? Consecutive = null, bool? Uploaded = null, string? LiquidationType = null, bool IncludeAnnulled = false);
