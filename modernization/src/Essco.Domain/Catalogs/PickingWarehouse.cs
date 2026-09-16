namespace Essco.Domain.Catalogs;

public sealed record PickingWarehouse
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public required string Location { get; init; }
    public int Racks { get; init; }
    public int Columns { get; init; }
    public bool IsDefault { get; init; }

    public IReadOnlyCollection<string> Validate()
    {
        var errors = new List<string>();
        if (Id <= 0) errors.Add("El código de bodega debe ser mayor que cero.");
        if (string.IsNullOrWhiteSpace(Name)) errors.Add("El nombre es obligatorio.");
        else if (Name.Trim().Length > 150) errors.Add("El nombre no puede superar 150 caracteres.");
        if (string.IsNullOrWhiteSpace(Location)) errors.Add("La ubicación es obligatoria.");
        else if (Location.Trim().Length > 250) errors.Add("La ubicación no puede superar 250 caracteres.");
        if (Racks <= 0) errors.Add("La cantidad de racks debe ser mayor que cero.");
        if (Columns <= 0) errors.Add("La cantidad de columnas debe ser mayor que cero.");
        return errors;
    }
}
