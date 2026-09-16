namespace Essco.Domain.Customers;

public sealed record CustomerExemption
{
    public long Id { get; init; }
    public required string CustomerCode { get; init; }
    public required string DocumentType { get; init; }
    public required string Number { get; init; }
    public required string Institution { get; init; }
    public DateOnly IssuedOn { get; init; }
    public DateOnly ExpiresOn { get; init; }
    public decimal PurchasePercent { get; init; }
    public bool Inactive { get; init; }

    public IReadOnlyCollection<string> Validate()
    {
        var errors = new List<string>();
        Required(CustomerCode, 50, "Cliente", errors);
        if (DocumentType is not ("01" or "02" or "03" or "04" or "05" or "06" or "07" or "99"))
            errors.Add("El tipo de documento de exoneración no es válido.");
        Required(Number, 100, "Número de exoneración", errors);
        Required(Institution, 200, "Institución", errors);
        if (IssuedOn == default || ExpiresOn == default) errors.Add("Las fechas de emisión y vencimiento son obligatorias.");
        else if (ExpiresOn < IssuedOn) errors.Add("La fecha de vencimiento no puede ser anterior a la emisión.");
        if (PurchasePercent is < 0 or > 100) errors.Add("El porcentaje de compra debe estar entre 0 y 100.");
        return errors;
    }
    private static void Required(string? value, int max, string name, ICollection<string> errors)
    { if (string.IsNullOrWhiteSpace(value)) errors.Add($"{name} es obligatorio."); else if (value.Trim().Length > max) errors.Add($"{name} no puede superar {max} caracteres."); }
}

public sealed record ExemptCabysCode(long Id, long ExemptionId, string CustomerCode, string CabysCode, bool Inactive);
