namespace Essco.Domain.Returns;
public sealed record ReturnRequest(int Number,DateOnly Date,string DriverCode,string DriverName,string CustomerCode,string CustomerName,bool Credit,decimal Total,string InvoiceNumber,string Reason,bool Processed,int? SapDocumentEntry,string Route,string SealNumber,string Comments,IReadOnlyCollection<ReturnLine> Lines);
public sealed record ReturnLine(int LineNumber,string ItemCode,string ItemName,decimal Price,decimal Quantity,decimal FixedDiscount,decimal PromotionalDiscount,decimal TaxPercent,decimal Total,string Reason,string Comments,string Warehouse);
public sealed record ReturnFilter(bool? Processed=null,string? DriverCode=null,int? Number=null);
