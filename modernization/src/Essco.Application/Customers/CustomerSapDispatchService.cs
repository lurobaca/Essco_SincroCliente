using System.Text.Json;
using Essco.Domain;
using Essco.Domain.Customers;
using Essco.SapBridge.Contracts;
namespace Essco.Application.Customers;

public sealed class CustomerSapDispatchService(ICustomerChangeRepository customers, ISapJobQueue queue)
{
    public async ValueTask<CustomerSapDispatchResult> DispatchAsync(long customerChangeId, string company, string requestedBy, CancellationToken token)
    {
        var customer = await customers.GetAsync(customerChangeId, token);
        if (customer is null) return new(false, null, "La solicitud de cliente no existe.");
        if (customer.Approved) return new(false, null, "La solicitud ya fue procesada.");
        var operation = customer.State switch { CustomerChangeState.New => CustomerSapOperations.Create, CustomerChangeState.Modified => CustomerSapOperations.Update, CustomerChangeState.Close => CustomerSapOperations.Close, CustomerChangeState.Internal => null, _ => null };
        if (operation is null) return new(false, null, "Los clientes internos no requieren procesamiento SAP.");
        var request = new CreateSapJobRequest(operation, company, requestedBy, JsonSerializer.Serialize(new CustomerSapPayload(customer.Id)), $"customer-change:{customer.Id}:{operation}");
        var job = await queue.EnqueueAsync(request, token); return new(true, job, null);
    }
}
public sealed record CustomerSapDispatchResult(bool Succeeded, SapJob? Job, string? Error);
