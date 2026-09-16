namespace Essco.Domain.Customers;
public enum AccountStatementStatus { All, Paid, Pending }
public sealed record AccountStatementEntry(string DocumentType,long DocumentNumber,string? Key,string? Sequence,DateTime DocumentDate,string CustomerName,decimal Total,decimal Subtotal,decimal Tax,decimal Balance,string Currency,decimal ExchangeRate,decimal ExemptedTax);
