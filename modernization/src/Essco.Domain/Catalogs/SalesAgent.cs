namespace Essco.Domain.Catalogs;

public sealed record SalesAgent
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
    public required string Group { get; init; }
    public required string ReturnSequence { get; init; }
    public required string NewCustomerSequence { get; init; }
    public required string Position { get; init; }

    public IReadOnlyCollection<string> Validate()
    {
        var errors = new List<string>();
        Required(Code, 50, "código", errors);
        Required(Name, 200, "nombre", errors);
        Required(Position, 20, "puesto", errors);
        if (Code.Trim() == "3") errors.Add("El código 3 está reservado por el sistema heredado.");
        if (Position is not ("AGENTE" or "CHOFER" or "AYUDANTE")) errors.Add("El puesto debe ser AGENTE, CHOFER o AYUDANTE.");
        if (!string.IsNullOrWhiteSpace(Email) && !Email.Contains('@', StringComparison.Ordinal)) errors.Add("El correo no tiene un formato válido.");
        return errors;
    }

    private static void Required(string value, int max, string label, ICollection<string> errors)
    {
        if (string.IsNullOrWhiteSpace(value)) errors.Add($"El {label} es obligatorio.");
        else if (value.Trim().Length > max) errors.Add($"El {label} no puede superar {max} caracteres.");
    }
}
