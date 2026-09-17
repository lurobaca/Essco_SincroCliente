using System.Text.Json;
using Essco.Application.Companies;
using Essco.Domain.Customers;
using Essco.SapBridge.Contracts;
namespace Essco.Application.Customers;

public interface ICustomerSapJobProcessor { ValueTask<SapProcessingResult> ProcessAsync(string operation, string payload, CancellationToken token); }
public sealed record SapProcessingResult(bool Succeeded, string? ExternalId, string? Error, bool Retryable);
public sealed record SapCustomerData(CustomerChangeRequest Customer, string Province, string Canton, string District, string Neighborhood);
public interface ISapCustomerGateway { ValueTask<SapProcessingResult> ExecuteAsync(string operation, SapCustomerData customer, CancellationToken token); }

public sealed class CustomerSapJobProcessor(ICustomerChangeRepository customers, IGeographyRepository geography, ISapCustomerGateway gateway) : ICustomerSapJobProcessor
{
    public async ValueTask<SapProcessingResult> ProcessAsync(string operation, string payload, CancellationToken token)
    {
        if (operation is not (CustomerSapOperations.Create or CustomerSapOperations.Update or CustomerSapOperations.Close))
            return new(false, null, "Operación SAP de cliente no soportada.", false);
        CustomerSapPayload? request;
        try { request = JsonSerializer.Deserialize<CustomerSapPayload>(payload); }
        catch (JsonException) { return new(false, null, "Payload de cliente inválido.", false); }
        if (request is null || request.CustomerChangeId <= 0)
            return new(false, null, "El identificador de solicitud del payload no es válido.", false);

        var customer = await customers.GetAsync(request.CustomerChangeId, token);
        if (customer is null) return new(false, null, "La solicitud de cliente ya no existe.", false);
        var expected = customer.State switch
        {
            CustomerChangeState.New => CustomerSapOperations.Create,
            CustomerChangeState.Modified => CustomerSapOperations.Update,
            CustomerChangeState.Close => CustomerSapOperations.Close,
            _ => null
        };
        if (expected != operation)
            return new(false, null, "La operación SAP no coincide con el estado actual de la solicitud.", false);
        if (customer.Approved) return new(true, customer.Code, null, false);
        var error = CustomerSapValidation.Error(customer);
        if (error is not null) return new(false, null, error, false);

        var data = new SapCustomerData(customer, "", "", "", "");
        if (operation != CustomerSapOperations.Close)
        {
            var province = Name(await geography.GetProvincesAsync(token), customer.ProvinceId);
            var canton = Name(await geography.GetCantonsAsync(customer.ProvinceId, token), customer.CantonId);
            var district = Name(await geography.GetDistrictsAsync(customer.ProvinceId, customer.CantonId, token), customer.DistrictId);
            var neighborhood = Name(await geography.GetNeighborhoodsAsync(customer.ProvinceId, customer.CantonId, customer.DistrictId, token), customer.NeighborhoodId);
            if (province is null || canton is null || district is null || neighborhood is null)
                return new(false, null, "La ubicación del cliente no existe o está duplicada en los catálogos. Revise provincia, cantón, distrito y barrio antes de reenviar.", false);
            data = new(customer, province, canton, district, neighborhood);
        }

        var result = await gateway.ExecuteAsync(operation, data, token);
        if (result.Succeeded && !await customers.ApproveAsync(customer.Id, token))
        {
            var current = await customers.GetAsync(customer.Id, token);
            if (current?.Approved != true)
                return new(false, null, "SAP respondió correctamente pero no se pudo confirmar la solicitud en SQL.", true);
        }
        return result;
    }

    private static string? Name(IEnumerable<LocationOption> values, int id)
    {
        var matches = values.Where(x => x.Id == id).Take(2).ToArray();
        return matches.Length == 1 && !string.IsNullOrWhiteSpace(matches[0].Name) ? matches[0].Name.Trim() : null;
    }
}

internal static class CustomerSapValidation
{
    public static string? Error(CustomerChangeRequest customer)
    {
        if (customer.State == CustomerChangeState.Close)
            return string.IsNullOrWhiteSpace(customer.Code) || customer.Code.Length > 50
                ? "El código del cliente no es válido para cerrar en SAP." : null;
        var errors = customer.Validate();
        return errors.Count == 0 ? null : "Corrija la solicitud antes de enviarla a SAP: " + string.Join(" ", errors);
    }
}
