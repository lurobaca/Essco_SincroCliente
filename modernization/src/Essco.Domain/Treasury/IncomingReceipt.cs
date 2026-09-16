namespace Essco.Domain.Treasury;

public sealed record IncomingReceipt(int DocEntry, int DocNumber, DateOnly Date, decimal Total,
    string CustomerCode, string CustomerName, string CollectorCode, string LiquidationNumber);

public sealed record IncomingReceiptFilter(DateOnly? From, DateOnly? To, string? CollectorCode,
    string? LiquidationNumber, int? DocNumber, bool OnlyUnlinked = false)
{
    public IReadOnlyCollection<string> Validate()
    {
        var errors = new List<string>();
        if (From is not null && To is not null && From > To) errors.Add("La fecha inicial no puede ser posterior a la final.");
        if (DocNumber is <= 0) errors.Add("El número de recibo debe ser mayor que cero.");
        return errors;
    }
}
