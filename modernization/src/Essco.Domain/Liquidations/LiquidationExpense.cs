namespace Essco.Domain.Liquidations;

public sealed record LiquidationExpense
{
    public int Id { get; init; }
    public required string DocumentNumber { get; init; }
    public required string Category { get; init; }
    public decimal Amount { get; init; }
    public required string Description { get; init; }
    public int? LiquidationNumber { get; init; }
    public required string LiquidationType { get; init; }
    public required string EmployeeCode { get; init; }
    public DateOnly Date { get; init; }
    public bool IsElectronicInvoice { get; init; }
    public required string SupplierCode { get; init; }
    public bool IncludeInLiquidation { get; init; }
    public bool IsAnnulled { get; init; }
    public required string HaciendaStatus { get; init; }
    public IReadOnlyCollection<string> Validate() { var e = new List<string>(); if (string.IsNullOrWhiteSpace(DocumentNumber)) e.Add("El número de documento es obligatorio."); if (string.IsNullOrWhiteSpace(Category)) e.Add("El tipo de gasto es obligatorio."); if (Amount <= 0) e.Add("El monto debe ser mayor que cero."); if (string.IsNullOrWhiteSpace(EmployeeCode)) e.Add("El empleado es obligatorio."); if (LiquidationType is not ("AGENTES" or "CHOFERES")) e.Add("El tipo debe ser AGENTES o CHOFERES."); return e; }
}
public sealed record LiquidationExpenseFilter(string? LiquidationType = null, int? LiquidationNumber = null, string? EmployeeCode = null, DateOnly? From = null, DateOnly? To = null, string? DocumentNumber = null, int? Id = null, bool? Included = null, bool IncludeAnnulled = false);
