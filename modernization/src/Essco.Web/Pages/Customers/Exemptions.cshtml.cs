using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Security.Claims;
using Essco.Application.Auditing;
using Essco.Application.Configuration;
using Essco.Application.Customers;
using Essco.Application.Security;
using Essco.Domain.Customers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Essco.Web.Pages.Customers;

[Authorize(Policy=Permissions.Customers)]
public sealed class ExemptionsModel(CustomerExemptionService service,AuditService audit,IOptions<EsscoOptions> options):PageModel
{
    [BindProperty(SupportsGet=true)] public string CustomerCode{get;set;}="";
    [BindProperty] public InputModel Input{get;set;}=new();
    [BindProperty] public string CabysCode{get;set;}="";
    public IReadOnlyCollection<CustomerExemption> Items{get;private set;}=[];
    public IReadOnlyCollection<ExemptCabysCode> Cabys{get;private set;}=[];
    [TempData] public string? StatusMessage{get;set;}

    public async Task<IActionResult> OnGetAsync(long? exemptionId,CancellationToken token)
    {
        if(string.IsNullOrWhiteSpace(CustomerCode))return BadRequest();
        if(exemptionId is not null){var item=await service.GetAsync(exemptionId.Value,token);if(item is null||!SameCustomer(item.CustomerCode))return NotFound();Input=InputModel.From(item);}
        await LoadAsync(token);return Page();
    }
    public async Task<IActionResult> OnPostSaveAsync(CancellationToken token)
    {
        CustomerExemption? old=null;if(Input.Id!=0){old=await service.GetAsync(Input.Id,token);if(old is null||!SameCustomer(old.CustomerCode))return NotFound();if(old.Inactive)return BadRequest();}
        if(ModelState.IsValid)
        {
            var result=await service.SaveAsync(Input.ToDomain(CustomerCode,old?.Inactive??false),token);
            if(result.Succeeded){await AuditAsync("customers.exemption-save",result.Id,"Succeeded",token);StatusMessage="Documento de exoneración guardado.";return RedirectToPage(new{CustomerCode,exemptionId=result.Id});}
            foreach(var error in result.Errors)ModelState.AddModelError(string.Empty,error);
        }
        await LoadAsync(token);return Page();
    }
    public async Task<IActionResult> OnPostDeactivateAsync(long id,CancellationToken token)
    {
        var item=await service.GetAsync(id,token);if(item is null||!SameCustomer(item.CustomerCode))return NotFound();var changed=await service.DeactivateAsync(id,token);await AuditAsync("customers.exemption-deactivate",id,changed?"Succeeded":"NotChanged",token);StatusMessage=changed?"Documento inactivado.":"El documento ya estaba inactivo.";return RedirectToPage(new{CustomerCode});
    }
    public async Task<IActionResult> OnPostAddCabysAsync(long exemptionId,CancellationToken token)
    {
        var item=await service.GetAsync(exemptionId,token);if(item is null||!SameCustomer(item.CustomerCode)||item.Inactive)return NotFound();var changed=await service.AddCabysAsync(exemptionId,CustomerCode,CabysCode,token);await AuditAsync("customers.exemption-cabys-add",exemptionId,changed?"Succeeded":"NotChanged",token);StatusMessage=changed?"Código CABYS agregado.":"El código no es válido o ya estaba asociado.";return RedirectToPage(new{CustomerCode,exemptionId});
    }
    public async Task<IActionResult> OnPostRemoveCabysAsync(long exemptionId,string cabys,CancellationToken token)
    {
        var item=await service.GetAsync(exemptionId,token);if(item is null||!SameCustomer(item.CustomerCode)||item.Inactive)return NotFound();var changed=await service.RemoveCabysAsync(exemptionId,cabys,token);await AuditAsync("customers.exemption-cabys-remove",exemptionId,changed?"Succeeded":"NotChanged",token);StatusMessage=changed?"Código CABYS eliminado.":"El código ya no existía.";return RedirectToPage(new{CustomerCode,exemptionId});
    }
    private async Task LoadAsync(CancellationToken token){Items=await service.ListAsync(CustomerCode,token);if(Input.Id!=0)Cabys=await service.ListCabysAsync(Input.Id,token);}
    private bool SameCustomer(string value)=>string.Equals(value,CustomerCode,StringComparison.OrdinalIgnoreCase);
    private async Task AuditAsync(string operation,long id,string outcome,CancellationToken token){var userId=int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier),NumberStyles.None,CultureInfo.InvariantCulture,out var parsed)?parsed:(int?)null;await audit.WriteAsync(userId,User.Identity?.Name??"",options.Value.DefaultCompany,operation,"DocumentosExoneracionDeClientes",id.ToString(CultureInfo.InvariantCulture),outcome,HttpContext.TraceIdentifier,HttpContext.Connection.RemoteIpAddress?.ToString(),token);}
    public sealed class InputModel
    {
        public long Id{get;set;}
        [Required,Display(Name="Tipo de documento")]public string DocumentType{get;set;}="01";
        [Required,StringLength(100),Display(Name="Número")]public string Number{get;set;}="";
        [Required,StringLength(200),Display(Name="Institución")]public string Institution{get;set;}="";
        [Required,DataType(DataType.Date),Display(Name="Fecha de emisión")]public DateOnly IssuedOn{get;set;}=DateOnly.FromDateTime(DateTime.Today);
        [Required,DataType(DataType.Date),Display(Name="Fecha de vencimiento")]public DateOnly ExpiresOn{get;set;}=DateOnly.FromDateTime(DateTime.Today);
        [Range(typeof(decimal),"0","100"),Display(Name="Porcentaje de compra")]public decimal PurchasePercent{get;set;}
        public CustomerExemption ToDomain(string code,bool inactive)=>new(){Id=Id,CustomerCode=code,DocumentType=DocumentType,Number=Number,Institution=Institution,IssuedOn=IssuedOn,ExpiresOn=ExpiresOn,PurchasePercent=PurchasePercent,Inactive=inactive};
        public static InputModel From(CustomerExemption x)=>new(){Id=x.Id,DocumentType=x.DocumentType,Number=x.Number,Institution=x.Institution,IssuedOn=x.IssuedOn,ExpiresOn=x.ExpiresOn,PurchasePercent=x.PurchasePercent};
    }
}
