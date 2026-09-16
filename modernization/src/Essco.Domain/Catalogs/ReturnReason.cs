namespace Essco.Domain.Catalogs;

public sealed record ReturnReason
{
    public int Code { get; init; }
    public required string Description { get; init; }
    public required string WarehouseCode { get; init; }
    public IReadOnlyCollection<string> Validate() { var errors = new List<string>(); if (string.IsNullOrWhiteSpace(Description)) errors.Add("La descripción es obligatoria."); else if (Description.Trim().Length > 150) errors.Add("La descripción no puede superar 150 caracteres."); if (string.IsNullOrWhiteSpace(WarehouseCode)) errors.Add("La bodega es obligatoria."); else if (WarehouseCode.Trim().Length > 20) errors.Add("El código de bodega no puede superar 20 caracteres."); return errors; }
}
public sealed record WarehouseOption(string Code, string Name);
