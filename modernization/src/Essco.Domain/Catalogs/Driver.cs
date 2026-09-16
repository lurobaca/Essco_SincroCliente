namespace Essco.Domain.Catalogs;

public sealed record Driver
{
    public required string Code { get; init; }
    public required string Identification { get; init; }
    public required string Name { get; init; }
    public required string Phone { get; init; }
    public required string OrderSequence { get; init; }
    public required string PaymentSequence { get; init; }
    public required string DepositSequence { get; init; }
    public required string ExpenseSequence { get; init; }
    public required string NoVisitSequence { get; init; }
    public required string Email { get; init; }
    public required string FtpPath { get; init; }
    public required string Type { get; init; }
    public required string ReturnSequence { get; init; }

    public IReadOnlyCollection<string> Validate()
    {
        var errors = new List<string>();
        if (string.IsNullOrWhiteSpace(Code)) errors.Add("El código es obligatorio.");
        else if (Code.Trim().Length > 50) errors.Add("El código no puede superar 50 caracteres.");
        if (string.IsNullOrWhiteSpace(Name)) errors.Add("El nombre es obligatorio.");
        else if (Name.Trim().Length > 200) errors.Add("El nombre no puede superar 200 caracteres.");
        if (Type is not ("CHOFER" or "AYUDANTE")) errors.Add("El tipo debe ser CHOFER o AYUDANTE.");
        if (!string.IsNullOrWhiteSpace(Email) && !Email.Contains('@', StringComparison.Ordinal)) errors.Add("El correo no tiene un formato válido.");
        return errors;
    }
}
