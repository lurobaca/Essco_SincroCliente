using System.Text.Json;
using Essco.Domain;
using Essco.Domain.Purchasing;
using Essco.SapBridge.Contracts;
using Essco.Application.Customers;

namespace Essco.Application.Purchasing;

public static class PurchaseOrderSapOperations { public const string Create = "PurchaseOrder.Create"; }
public sealed record PurchaseOrderSapPayload(int Number);
public interface IPurchaseOrderRepository
{
    ValueTask<IReadOnlyCollection<PurchaseOrder>> ListAsync(PurchaseOrderFilter filter, CancellationToken token);
    ValueTask<PurchaseOrder?> GetAsync(int number, CancellationToken token);
    ValueTask<bool> UpdateLineAsync(int number, PurchaseOrderLine line, CancellationToken token);
    ValueTask<bool> CancelAsync(int number, CancellationToken token);
    ValueTask<bool> MarkCreatedAsync(int number, int sapEntry, CancellationToken token);
}

public sealed class PurchaseOrderService(IPurchaseOrderRepository repository, ISapJobQueue queue)
{
    public ValueTask<IReadOnlyCollection<PurchaseOrder>> ListAsync(PurchaseOrderFilter filter, CancellationToken token) => repository.ListAsync(filter, token);
    public ValueTask<PurchaseOrder?> GetAsync(int number, CancellationToken token) => repository.GetAsync(number, token);
    public async ValueTask<(bool Succeeded, IReadOnlyCollection<string> Errors)> UpdateLineAsync(int number, PurchaseOrderLine line, CancellationToken token)
    {
        var errors = line.Validate();
        if (errors.Count > 0) return (false, errors);
        return await repository.UpdateLineAsync(number, line, token) ? (true, []) : (false, ["La línea dejó de estar disponible."]);
    }
    public ValueTask<bool> CancelAsync(int number, CancellationToken token) => repository.CancelAsync(number, token);
    public async ValueTask<(bool Succeeded, SapJob? Job, string? Error)> DispatchAsync(int number, string company, string user, CancellationToken token)
    {
        var order = await repository.GetAsync(number, token);
        if (order is null) return (false, null, "El pedido no existe.");
        if (order.Closed) return (false, null, "El pedido está anulado o cerrado.");
        if (order.CreatedInSap) return (false, null, "El pedido ya fue creado en SAP.");
        if (order.Lines.Count == 0 || order.Lines.All(x => x.Units <= 0)) return (false, null, "El pedido no contiene cantidades para procesar.");
        var job = await queue.EnqueueAsync(new(PurchaseOrderSapOperations.Create, company, user, JsonSerializer.Serialize(new PurchaseOrderSapPayload(number)), $"purchase-order:{number}:create"), token);
        return (true, job, null);
    }
}
public interface ISapPurchaseOrderGateway { ValueTask<SapProcessingResult> CreateAsync(PurchaseOrder order, CancellationToken token); }
public interface IPurchaseOrderSapJobProcessor { ValueTask<SapProcessingResult> ProcessAsync(string operation, string payload, CancellationToken token); }
public sealed class PurchaseOrderSapJobProcessor(IPurchaseOrderRepository repository, ISapPurchaseOrderGateway gateway) : IPurchaseOrderSapJobProcessor
{
    public async ValueTask<SapProcessingResult> ProcessAsync(string operation, string payload, CancellationToken token)
    {
        if (operation != PurchaseOrderSapOperations.Create) return new(false, null, "Operación de pedido no soportada.", false);
        PurchaseOrderSapPayload? data;
        try { data = JsonSerializer.Deserialize<PurchaseOrderSapPayload>(payload); }
        catch (JsonException) { return new(false, null, "Payload de pedido inválido.", false); }
        if (data is null) return new(false, null, "Payload de pedido vacío.", false);
        var order = await repository.GetAsync(data.Number, token);
        if (order is null) return new(false, null, "El pedido ya no existe.", false);
        if (order.CreatedInSap) return new(true, order.Number.ToString(), null, false);
        var result = await gateway.CreateAsync(order, token);
        if (!result.Succeeded) return result;
        if (!int.TryParse(result.ExternalId, out var entry)) return new(false, result.ExternalId, "SAP creó el pedido sin devolver DocEntry válido; requiere conciliación.", false);
        return await repository.MarkCreatedAsync(order.Number, entry, token) ? result : new(false, result.ExternalId, "SAP creó el pedido pero SQL no pudo confirmarlo; requiere conciliación.", false);
    }
}
