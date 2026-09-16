namespace Essco.Domain.Purchasing;

public sealed record PurchaseOrder(int Number, DateOnly Date, string SupplierCode, string SupplierName, bool Closed, bool CreatedInSap, IReadOnlyCollection<PurchaseOrderLine> Lines)
{
    public decimal Total => Lines.Sum(x => x.Total);
}

public sealed record PurchaseOrderLine(long Id, string ItemCode, string Description, decimal Cost, decimal Pack, decimal Units, decimal Cases, decimal Total, bool Reviewed, string Reason)
{
    public IReadOnlyCollection<string> Validate()
    {
        var errors = new List<string>();
        if (string.IsNullOrWhiteSpace(ItemCode)) errors.Add("El artículo es obligatorio.");
        if (Cost < 0 || Pack < 0 || Units < 0 || Cases < 0 || Total < 0) errors.Add("Costos y cantidades no pueden ser negativos.");
        return errors;
    }
}

public sealed record PurchaseOrderFilter(int? Number = null, string? Supplier = null, DateOnly? From = null, DateOnly? To = null, bool? CreatedInSap = null);
