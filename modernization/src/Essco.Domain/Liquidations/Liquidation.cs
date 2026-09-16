namespace Essco.Domain.Liquidations;

public enum LiquidationKind { Agents, Drivers }
public sealed record Liquidation
{
    public int Consecutive { get; init; }
    public LiquidationKind Kind { get; init; }
    public DateOnly Date { get; init; }
    public required string EmployeeCode { get; init; }
    public required string Identification { get; init; }
    public required string EmployeeName { get; init; }
    public DateOnly From { get; init; }
    public DateOnly To { get; init; }
    public DateOnly ReceiptFrom { get; init; }
    public DateOnly ReceiptTo { get; init; }
    public required string Notes { get; init; }
    public required string Type { get; init; }
    public decimal Result { get; init; }
    public required string Route { get; init; }
    public required string AgentCodes { get; init; }
    public required string InvoiceReportCodes { get; init; }
    public bool IsAnnulled { get; init; }
    public IReadOnlyCollection<string> Validate()
    {
        var errors=new List<string>();
        if(string.IsNullOrWhiteSpace(EmployeeCode))errors.Add("El código del empleado es obligatorio.");
        if(string.IsNullOrWhiteSpace(EmployeeName))errors.Add("El nombre del empleado es obligatorio.");
        if(From>To)errors.Add("El rango principal de fechas es inválido.");
        if(Kind==LiquidationKind.Drivers&&ReceiptFrom>ReceiptTo)errors.Add("El rango de recibos es inválido.");
        if(string.IsNullOrWhiteSpace(Type))errors.Add("El tipo de liquidación es obligatorio.");
        return errors;
    }
}
public sealed record LiquidationFilter(LiquidationKind Kind,DateOnly? From=null,DateOnly? To=null,int? Consecutive=null,bool IncludeAnnulled=false);
public sealed record LiquidationSummary(decimal Invoices,decimal Deposits,decimal Receipts,decimal Expenses)
{
    public decimal Result => Deposits + Expenses - Receipts;
}
