namespace Essco.Domain.Products;

public sealed record Product(
    string Code,
    string Description,
    string ForeignName,
    string Group,
    string Location,
    string Cabys,
    string Barcode,
    decimal Price,
    string Currency,
    string AlternateCode,
    decimal TaxRate,
    string SupplierCode,
    string Packaging,
    string Unit,
    string ProductType,
    string Family,
    string Category,
    string Brand,
    bool Taxable,
    bool CreatedInSap);

public sealed record ProductFilter(
    string? Search = null,
    string? ProductType = null,
    bool SearchDescription = true);

public sealed record AutomaticDiscount
{
    public required string ProductCode { get; init; }
    public required string Description { get; init; }
    public decimal Percentage { get; init; }
    public DateOnly From { get; init; }
    public DateOnly To { get; init; }
    public decimal MinimumQuantity { get; init; }
    public decimal AvailableQuantity { get; init; }
    public required string Comments { get; init; }

    /// <summary>Devuelve todas las reglas incumplidas por el descuento.</summary>
    public IReadOnlyCollection<string> Validate()
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(ProductCode))
        {
            errors.Add("El artículo es obligatorio.");
        }

        if (Percentage is < 0 or > 100)
        {
            errors.Add("El descuento debe estar entre 0 y 100.");
        }

        if (From > To)
        {
            errors.Add("El rango de fechas es inválido.");
        }

        if (MinimumQuantity < 0 || AvailableQuantity < 0)
        {
            errors.Add("Las cantidades no pueden ser negativas.");
        }

        return errors;
    }
}

public sealed record PriceList(int Id, string Name, bool IsInactive);
