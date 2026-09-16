namespace Essco.Domain.Catalogs;

public sealed record CompanyBank
{
    public required string Code { get; init; }
    public required string Name { get; init; }
    public required string Account { get; init; }

    public IReadOnlyCollection<string> Validate()
    {
        var errors = new List<string>();
        if (string.IsNullOrWhiteSpace(Code)) errors.Add("El código es obligatorio.");
        else if (Code.Trim().Length > 50) errors.Add("El código no puede superar 50 caracteres.");
        if (string.IsNullOrWhiteSpace(Name)) errors.Add("El nombre es obligatorio.");
        else if (Name.Trim().Length > 200) errors.Add("El nombre no puede superar 200 caracteres.");
        if (string.IsNullOrWhiteSpace(Account)) errors.Add("La cuenta asignada es obligatoria.");
        else if (Account.Trim().Length > 100) errors.Add("La cuenta asignada no puede superar 100 caracteres.");
        return errors;
    }
}
