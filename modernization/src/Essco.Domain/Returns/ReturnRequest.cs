namespace Essco.Domain.Returns;
public sealed record ReturnRequest(int Number,DateOnly Date,string DriverCode,string DriverName,string CustomerCode,string CustomerName,bool Credit,decimal Total,string InvoiceNumber,string Reason,bool Processed,int? SapDocumentEntry,string Route,string SealNumber,string Comments,IReadOnlyCollection<ReturnLine> Lines);
public sealed record ReturnLine(int LineNumber,string ItemCode,string ItemName,decimal Price,decimal Quantity,decimal FixedDiscount,decimal PromotionalDiscount,decimal TaxPercent,decimal Total,string Reason,string Comments,string Warehouse);
public sealed record ReturnLineDraft(int ReturnNumber,int LineNumber,decimal Quantity,decimal FixedDiscount,decimal PromotionalDiscount,string Reason,string Comments)
{
    public IReadOnlyCollection<string> Validate()
    {
        var errors=new List<string>();
        if(ReturnNumber<=0) errors.Add("La devolución es obligatoria.");
        if(LineNumber<0) errors.Add("La línea no es válida.");
        if(Quantity<=0 || Quantity!=decimal.Truncate(Quantity) || Quantity>int.MaxValue) errors.Add("La cantidad debe ser un entero mayor que cero.");
        if(FixedDiscount is <0 or >100 || PromotionalDiscount is <0 or >100 || FixedDiscount+PromotionalDiscount>100) errors.Add("Los descuentos deben estar entre 0 y 100 y no superar 100 en total.");
        if(string.IsNullOrWhiteSpace(Reason)) errors.Add("El motivo es obligatorio."); else if(Reason.Trim().Length>200) errors.Add("El motivo no puede superar 200 caracteres.");
        if((Comments?.Trim().Length??0)>200) errors.Add("Los comentarios no pueden superar 200 caracteres.");
        return errors;
    }
}
public sealed record ReturnFilter(bool? Processed=null,string? DriverCode=null,int? Number=null);
