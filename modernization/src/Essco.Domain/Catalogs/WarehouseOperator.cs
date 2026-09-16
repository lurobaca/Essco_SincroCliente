namespace Essco.Domain.Catalogs;

public sealed record WarehouseOperator
{
    public required string Code { get; init; }
    public required string Name { get; init; }
    public required string Phone { get; init; }
    public required string LoadSequence { get; init; }
    public required string ReturnSequence { get; init; }
    public required string Email { get; init; }
    public required string FtpPath { get; init; }
    public required string Position { get; init; }
    public required string Identification { get; init; }
    public required string Username { get; init; }
    public IReadOnlyCollection<int> Sectors { get; init; } = [];

    public IReadOnlyCollection<string> Validate()
    {
        var errors = new List<string>();
        Required(Code, 50, "código", errors);
        Required(Name, 200, "nombre", errors);
        Required(Username, 100, "usuario", errors);
        Required(Position, 100, "puesto", errors);
        if (!string.IsNullOrWhiteSpace(Email) && !Email.Contains('@', StringComparison.Ordinal)) errors.Add("El correo no tiene un formato válido.");
        if (Sectors.Any(x => x is < 1 or > 20) || Sectors.Count != Sectors.Distinct().Count()) errors.Add("Los sectores deben ser valores únicos entre 1 y 20.");
        return errors;
    }

    private static void Required(string value, int max, string label, ICollection<string> errors)
    {
        if (string.IsNullOrWhiteSpace(value)) errors.Add($"El {label} es obligatorio.");
        else if (value.Trim().Length > max) errors.Add($"El {label} no puede superar {max} caracteres.");
    }
}
