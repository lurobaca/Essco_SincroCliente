using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Security.Claims;
using Essco.Application.Auditing;
using Essco.Application.Catalogs;
using Essco.Application.Configuration;
using Essco.Application.Security;
using Essco.Domain.Catalogs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
namespace Essco.Web.Pages.Catalogs;
[Authorize(Policy=Permissions.Catalogs)]
public sealed class DriversModel(DriverService service,AuditService audit,IOptions<EsscoOptions> options):PageModel
{
    [BindProperty]public InputModel Input{get;set;}=new();[BindProperty(SupportsGet=true)]public string? TypeFilter{get;set;}public IReadOnlyCollection<Driver> Items{get;private set;}=[];[TempData]public string? StatusMessage{get;set;}public static IReadOnlyCollection<string> Types{get;}=["CHOFER","AYUDANTE"];
    public async Task OnGetAsync(string? code,CancellationToken token){Items=await service.ListAsync(TypeFilter,token);var item=string.IsNullOrWhiteSpace(code)?null:Items.FirstOrDefault(x=>string.Equals(x.Code,code,StringComparison.OrdinalIgnoreCase));if(item is not null)Input=InputModel.From(item);}
    public async Task<IActionResult> OnPostSaveAsync(CancellationToken token){if(ModelState.IsValid){var result=await service.SaveAsync(Input.ToDomain(),Input.IsNew,token);if(result.Succeeded){await Log("catalog.driver-save",Input.Code,"Succeeded",token);StatusMessage="Chofer guardado.";return RedirectToPage(new{TypeFilter});}foreach(var error in result.Errors)ModelState.AddModelError(string.Empty,error);}Items=await service.ListAsync(TypeFilter,token);return Page();}
    public async Task<IActionResult> OnPostDeleteAsync(string code,CancellationToken token){var changed=!string.IsNullOrWhiteSpace(code)&&await service.DeleteAsync(code,token);await Log("catalog.driver-delete",code,changed?"Succeeded":"NotChanged",token);StatusMessage=changed?"Chofer eliminado.":"El chofer ya no existía.";return RedirectToPage(new{TypeFilter});}
    private async Task Log(string operation,string code,string result,CancellationToken token){var userId=int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier),NumberStyles.None,CultureInfo.InvariantCulture,out var parsed)?parsed:(int?)null;await audit.WriteAsync(userId,User.Identity?.Name??"",options.Value.DefaultCompany,operation,"Choferes",code,result,HttpContext.TraceIdentifier,HttpContext.Connection.RemoteIpAddress?.ToString(),token);}
    public sealed class InputModel
    {
        public bool IsNew{get;set;}=true;[Required,StringLength(50),Display(Name="Código")]public string Code{get;set;}="";[StringLength(50),Display(Name="Cédula")]public string Identification{get;set;}="";[Required,StringLength(200),Display(Name="Nombre")]public string Name{get;set;}="";[StringLength(50),Display(Name="Teléfono")]public string Phone{get;set;}="";[StringLength(50),Display(Name="Pedidos")]public string OrderSequence{get;set;}="";[StringLength(50),Display(Name="Pagos")]public string PaymentSequence{get;set;}="";[StringLength(50),Display(Name="Depósitos")]public string DepositSequence{get;set;}="";[StringLength(50),Display(Name="Gastos")]public string ExpenseSequence{get;set;}="";[StringLength(50),Display(Name="No visitas")]public string NoVisitSequence{get;set;}="";[StringLength(254),EmailAddress,Display(Name="Correo")]public string Email{get;set;}="";[StringLength(500),Display(Name="Ruta FTP")]public string FtpPath{get;set;}="";[Required,Display(Name="Tipo")]public string Type{get;set;}="CHOFER";[StringLength(50),Display(Name="Devoluciones")]public string ReturnSequence{get;set;}="";
        public Driver ToDomain()=>new(){Code=Code,Identification=Identification,Name=Name,Phone=Phone,OrderSequence=OrderSequence,PaymentSequence=PaymentSequence,DepositSequence=DepositSequence,ExpenseSequence=ExpenseSequence,NoVisitSequence=NoVisitSequence,Email=Email,FtpPath=FtpPath,Type=Type,ReturnSequence=ReturnSequence};
        public static InputModel From(Driver x)=>new(){IsNew=false,Code=x.Code,Identification=x.Identification,Name=x.Name,Phone=x.Phone,OrderSequence=x.OrderSequence,PaymentSequence=x.PaymentSequence,DepositSequence=x.DepositSequence,ExpenseSequence=x.ExpenseSequence,NoVisitSequence=x.NoVisitSequence,Email=x.Email,FtpPath=x.FtpPath,Type=x.Type,ReturnSequence=x.ReturnSequence};
    }
}
