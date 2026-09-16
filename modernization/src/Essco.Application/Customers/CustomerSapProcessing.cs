using System.Text.Json;
using Essco.Application.Companies;
using Essco.Domain.Customers;
using Essco.SapBridge.Contracts;
namespace Essco.Application.Customers;
public interface ICustomerSapJobProcessor{ValueTask<SapProcessingResult> ProcessAsync(string operation,string payload,CancellationToken token);}
public sealed record SapProcessingResult(bool Succeeded,string? ExternalId,string? Error,bool Retryable);
public sealed record SapCustomerData(CustomerChangeRequest Customer,string Province,string Canton,string District,string Neighborhood);
public interface ISapCustomerGateway{ValueTask<SapProcessingResult> ExecuteAsync(string operation,SapCustomerData customer,CancellationToken token);}
public sealed class CustomerSapJobProcessor(ICustomerChangeRepository customers,IGeographyRepository geography,ISapCustomerGateway gateway):ICustomerSapJobProcessor
{
 public async ValueTask<SapProcessingResult> ProcessAsync(string operation,string payload,CancellationToken token)
 {
  CustomerSapPayload? request;try{request=JsonSerializer.Deserialize<CustomerSapPayload>(payload);}catch(JsonException){return new(false,null,"Payload de cliente inválido.",false);}if(request is null)return new(false,null,"Payload de cliente vacío.",false);
  var customer=await customers.GetAsync(request.CustomerChangeId,token);if(customer is null)return new(false,null,"La solicitud de cliente ya no existe.",false);if(customer.Approved)return new(true,customer.Code,null,false);
  var expected=customer.State switch{CustomerChangeState.New=>CustomerSapOperations.Create,CustomerChangeState.Modified=>CustomerSapOperations.Update,CustomerChangeState.Close=>CustomerSapOperations.Close,_=>null};if(expected!=operation)return new(false,null,"La operación SAP no coincide con el estado actual de la solicitud.",false);
  var data=new SapCustomerData(customer,Name(await geography.GetProvincesAsync(token),customer.ProvinceId),Name(await geography.GetCantonsAsync(customer.ProvinceId,token),customer.CantonId),Name(await geography.GetDistrictsAsync(customer.ProvinceId,customer.CantonId,token),customer.DistrictId),Name(await geography.GetNeighborhoodsAsync(customer.ProvinceId,customer.CantonId,customer.DistrictId,token),customer.NeighborhoodId));
  var result=await gateway.ExecuteAsync(operation,data,token);if(result.Succeeded&&!await customers.ApproveAsync(customer.Id,token)){var current=await customers.GetAsync(customer.Id,token);if(current?.Approved!=true)return new(false,null,"SAP respondió correctamente pero no se pudo confirmar la solicitud en SQL.",true);}return result;
 }
 private static string Name(IEnumerable<LocationOption> values,int id)=>values.FirstOrDefault(x=>x.Id==id)?.Name??id.ToString(System.Globalization.CultureInfo.InvariantCulture);
}
