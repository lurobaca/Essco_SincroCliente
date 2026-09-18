using System.ComponentModel.DataAnnotations;
using Essco.Application.Auditing;
using Essco.Application.Configuration;
using Essco.Application.Returns;
using Essco.Application.Security;
using Essco.Domain.Returns;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Essco.Web.Pages.Returns;

[Authorize(Policy=Permissions.Billing)]
public sealed class IndexModel(ReturnService service,AuditService audit,IOptions<EsscoOptions> options):PageModel
{
    [BindProperty(SupportsGet=true)] public FilterModel Filter {get;set;}=new();
    [BindProperty] public LineInput Input {get;set;}=new();
    [BindProperty] public NewLineInput NewLine {get;set;}=new();
    public IReadOnlyCollection<ReturnRequest> Items {get;private set;}=[];
    public ReturnRequest? Selected {get;private set;}
    [TempData] public string? StatusMessage {get;set;}

    public async Task OnGetAsync(int? view,CancellationToken token)=>await LoadAsync(view,token);

    public async Task<IActionResult> OnPostSaveLineAsync(CancellationToken token)
    {
        var succeeded=false;
        IReadOnlyCollection<string> errors=[];
        if(ModelState.IsValid)
        {
            var result=await service.SaveLineAsync(Input.ToDomain(),token);
            succeeded=result.Succeeded;
            errors=result.Errors;
        }
        else errors=ModelState.Values.SelectMany(x=>x.Errors).Select(x=>x.ErrorMessage).ToArray();
        await audit.WriteAsync(null,User.Identity?.Name??"",options.Value.DefaultCompany,
            "return.line-update","DevolucionesDetalle",$"{Input.Number}:{Input.LineNumber}",
            succeeded?"Succeeded":"Rejected",HttpContext.TraceIdentifier,
            HttpContext.Connection.RemoteIpAddress?.ToString(),token);
        StatusMessage=succeeded?"La línea se guardó y los totales se recalcularon. No se envió a SAP.":
            string.Join(" ",errors);
        return RedirectToPage(new {view=Input.Number});
    }

    public async Task<IActionResult> OnPostProcessAsync(int number,CancellationToken token)
    {
        var result=await service.DispatchAsync(number,options.Value.DefaultCompany,User.Identity?.Name??"",token);
        await audit.WriteAsync(null,User.Identity?.Name??"",options.Value.DefaultCompany,
            "return.process","Devoluciones",number.ToString(),result.Succeeded?"Queued":"Rejected",
            HttpContext.TraceIdentifier,HttpContext.Connection.RemoteIpAddress?.ToString(),token);
        StatusMessage=result.Succeeded?$"Devolución encolada. Trabajo: {result.Job!.Id}":result.Error;
        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostAddLineAsync(CancellationToken token)
    {
        (bool Succeeded,IReadOnlyCollection<string> Errors) result;
        if(ModelState.IsValid) result=await service.AddLineAsync(NewLine.ToDomain(),token);
        else result=(false,ModelState.Values.SelectMany(x=>x.Errors).Select(x=>x.ErrorMessage).ToArray());
        await WriteLineAudit("return.line-add",NewLine.Number,-1,result.Succeeded?"Succeeded":"Rejected",token);
        StatusMessage=result.Succeeded?"Artículo agregado al preliminar. Indica la cantidad y el motivo antes de procesar.":string.Join(" ",result.Errors);
        return RedirectToPage(new {view=NewLine.Number});
    }

    public async Task<IActionResult> OnPostDeleteLineAsync(int number,int lineNumber,CancellationToken token)
    {
        var result=await service.DeleteLineAsync(number,lineNumber,token);
        await WriteLineAudit("return.line-delete",number,lineNumber,result.Succeeded?"Succeeded":"Rejected",token);
        StatusMessage=result.Succeeded?"La línea se eliminó y los totales se recalcularon.":result.Error;
        return RedirectToPage(new {view=number});
    }

    private async Task LoadAsync(int? view,CancellationToken token)
    {
        Items=await service.ListAsync(Filter.Domain(),token);
        if(view is not null) Selected=await service.GetAsync(view.Value,token);
    }

    private Task WriteLineAudit(string operation,int number,int line,string outcome,CancellationToken token)=>audit.WriteAsync(null,User.Identity?.Name??"",options.Value.DefaultCompany,operation,"DevolucionesDetalle",$"{number}:{line}",outcome,HttpContext.TraceIdentifier,HttpContext.Connection.RemoteIpAddress?.ToString(),token).AsTask();

    public sealed class FilterModel
    {
        public string? Driver {get;set;}
        public int? Number {get;set;}
        public string Status {get;set;}="Pending";
        public ReturnFilter Domain()=>new(Status=="All"?null:Status=="Processed",Driver,Number);
    }
    public sealed class LineInput
    {
        [Range(1,int.MaxValue)] public int Number {get;set;}
        [Range(0,int.MaxValue)] public int LineNumber {get;set;}
        [Range(1,int.MaxValue)] public decimal Quantity {get;set;}
        [Range(typeof(decimal),"0","100")] public decimal FixedDiscount {get;set;}
        [Range(typeof(decimal),"0","100")] public decimal PromotionalDiscount {get;set;}
        [Required,StringLength(200)] public string Reason {get;set;}="";
        [StringLength(200)] public string? Comments {get;set;}
        public ReturnLineDraft ToDomain()=>new(Number,LineNumber,Quantity,FixedDiscount,PromotionalDiscount,Reason,Comments??"");
    }
    public sealed class NewLineInput
    {
        [Range(1,int.MaxValue)] public int Number {get;set;}
        [Required,StringLength(10)] public string ItemCode {get;set;}="";
        [Required,StringLength(100)] public string ItemName {get;set;}="";
        [Range(typeof(decimal),"0","999999999")] public decimal Price {get;set;}
        [Range(typeof(decimal),"0","100")] public decimal TaxPercent {get;set;}
        public NewReturnLine ToDomain()=>new(Number,ItemCode,ItemName,Price,TaxPercent);
    }
}
