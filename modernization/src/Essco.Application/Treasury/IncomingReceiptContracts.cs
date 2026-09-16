using System.Text.Json;
using Essco.Domain;
using Essco.Domain.Treasury;
using Essco.SapBridge.Contracts;
using Essco.Application.Customers;

namespace Essco.Application.Treasury;

public static class IncomingReceiptSapOperations { public const string Link = "IncomingReceipt.Link"; public const string Unlink = "IncomingReceipt.Unlink"; }
public sealed record IncomingReceiptSapPayload(int DocEntry, int DocNumber, string CollectorCode, string LiquidationNumber);

public interface IIncomingReceiptRepository
{
    ValueTask<IReadOnlyCollection<IncomingReceipt>> ListAsync(IncomingReceiptFilter filter, CancellationToken token);
    ValueTask<IncomingReceipt?> GetAsync(int docEntry, CancellationToken token);
}

public sealed class IncomingReceiptService(IIncomingReceiptRepository repository, ISapJobQueue queue)
{
    public async ValueTask<(IReadOnlyCollection<IncomingReceipt> Items, IReadOnlyCollection<string> Errors)> ListAsync(IncomingReceiptFilter filter, CancellationToken token)
    {
        var errors = filter.Validate();
        return errors.Count > 0 ? ([], errors) : (await repository.ListAsync(filter, token), []);
    }

    public async ValueTask<(bool Succeeded, SapJob? Job, string? Error)> DispatchAsync(int docEntry, string collectorCode,
        string liquidationNumber, bool unlink, string company, string requestedBy, CancellationToken token)
    {
        if (docEntry <= 0) return (false, null, "El recibo es inválido.");
        var receipt = await repository.GetAsync(docEntry, token);
        if (receipt is null) return (false, null, "El recibo no existe o está anulado en SAP.");
        collectorCode = collectorCode.Trim(); liquidationNumber = liquidationNumber.Trim();
        if (!unlink && (collectorCode.Length == 0 || liquidationNumber.Length == 0)) return (false, null, "Cobrador y liquidación son obligatorios.");
        var operation = unlink ? IncomingReceiptSapOperations.Unlink : IncomingReceiptSapOperations.Link;
        var payload = new IncomingReceiptSapPayload(receipt.DocEntry, receipt.DocNumber, unlink ? "" : collectorCode, unlink ? "" : liquidationNumber);
        var job = await queue.EnqueueAsync(new(operation, company, requestedBy, JsonSerializer.Serialize(payload),
            $"incoming-receipt:{receipt.DocEntry}:{operation}:{payload.CollectorCode}:{payload.LiquidationNumber}"), token);
        return (true, job, null);
    }
}

public interface IIncomingReceiptSapJobProcessor { ValueTask<SapProcessingResult> ProcessAsync(string operation, string payload, CancellationToken token); }
public interface ISapIncomingReceiptGateway { ValueTask<SapProcessingResult> ExecuteAsync(string operation, IncomingReceiptSapPayload receipt, CancellationToken token); }
public sealed class IncomingReceiptSapJobProcessor(ISapIncomingReceiptGateway gateway) : IIncomingReceiptSapJobProcessor
{
    public ValueTask<SapProcessingResult> ProcessAsync(string operation, string payload, CancellationToken token)
    {
        IncomingReceiptSapPayload? receipt;
        try { receipt = JsonSerializer.Deserialize<IncomingReceiptSapPayload>(payload); }
        catch (JsonException) { return ValueTask.FromResult(new SapProcessingResult(false, null, "Payload de recibo inválido.", false)); }
        if (receipt is null || receipt.DocEntry <= 0) return ValueTask.FromResult(new SapProcessingResult(false, null, "Payload de recibo vacío.", false));
        if (operation is not (IncomingReceiptSapOperations.Link or IncomingReceiptSapOperations.Unlink)) return ValueTask.FromResult(new SapProcessingResult(false, null, "Operación de recibo no soportada.", false));
        return gateway.ExecuteAsync(operation, receipt, token);
    }
}
