namespace Essco.Domain.Billing;

public sealed record ElectronicInvoice(string DocumentNumber, string Key, string Consecutive, DateOnly IssueDate, DateOnly DueDate, string CustomerCode, string CustomerName, string CustomerIdentification, string Currency, decimal ExchangeRate, decimal Subtotal, decimal Discount, decimal Tax, decimal Total, string Status, string HaciendaStatus, string HaciendaMessage, string Comments, IReadOnlyCollection<ElectronicInvoiceLine> Lines);
public sealed record ElectronicInvoiceLine(int Number, string ItemCode, string Description, string Unit, decimal Quantity, decimal UnitPrice, decimal Discount, decimal Tax, decimal Total, string Cabys, string TaxCode, decimal ExemptionPercentage, decimal ExemptionAmount);
public sealed record ElectronicInvoiceFilter(string? Search = null, DateOnly? From = null, DateOnly? To = null, string? HaciendaStatus = null);
