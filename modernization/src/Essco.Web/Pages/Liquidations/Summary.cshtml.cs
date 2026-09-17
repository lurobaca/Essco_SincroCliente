using System.Globalization;
using System.Security.Claims;
using Essco.Application.Auditing;
using Essco.Application.Configuration;
using Essco.Application.Liquidations;
using Essco.Application.Security;
using Essco.Domain.Liquidations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
namespace Essco.Web.Pages.Liquidations;

[Authorize(Policy=Permissions.LiquidationDifferences)]
public sealed class SummaryModel(LiquidationService service,AuditService audit,IOptions<EsscoOptions> options):PageModel
{
    public Liquidation Liquidation{get;private set;}=null!;
    public LiquidationSummary Summary{get;private set;}=null!;
    [TempData]public string?StatusMessage{get;set;}
    public async Task<IActionResult>OnGetAsync(LiquidationKind kind,int number,CancellationToken token)
    {
        if(!ModelState.IsValid||!Enum.IsDefined(kind)||number<=0)return BadRequest("Tipo o consecutivo inválido.");
        var value=(await service.ListAsync(new(kind,Consecutive:number,IncludeAnnulled:true),token)).FirstOrDefault();
        var summary=await service.GetSummaryAsync(kind,number,token);
        if(value is null||summary is null)return NotFound();
        Liquidation=value;Summary=summary;return Page();
    }
    public async Task<IActionResult>OnPostRecalculateAsync(LiquidationKind kind,int number,CancellationToken token)
    {
        if(!ModelState.IsValid||!Enum.IsDefined(kind)||number<=0)return BadRequest("Tipo o consecutivo inválido.");
        var succeeded=await service.RecalculateAsync(kind,number,token);
        var userId=int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier),NumberStyles.None,CultureInfo.InvariantCulture,out var parsed)?parsed:(int?)null;
        await audit.WriteAsync(userId,User.Identity?.Name??"",options.Value.DefaultCompany,
            "liquidation.recalculate",kind.ToString(),number.ToString(CultureInfo.InvariantCulture),
            succeeded?"Succeeded":"Rejected",HttpContext.TraceIdentifier,HttpContext.Connection.RemoteIpAddress?.ToString(),token);
        StatusMessage=succeeded?"Resultado recalculado.":"No fue posible recalcular.";
        return RedirectToPage(new{kind,number});
    }
}
