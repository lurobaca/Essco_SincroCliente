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
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
namespace Essco.Web.Pages.Catalogs;

[Authorize(Policy = Permissions.Catalogs)]
public sealed class ReturnReasonsModel(ReturnReasonService service, AuditService audit, IOptions<EsscoOptions> options) : PageModel
{
    [BindProperty] public InputModel Input { get; set; } = new(); public IReadOnlyCollection<ReturnReason> Items { get; private set; } = []; public IReadOnlyCollection<SelectListItem> Warehouses { get; private set; } = []; [TempData] public string? StatusMessage { get; set; }
    public async Task OnGetAsync(int? code, CancellationToken token) { await Load(token); if (code is not null) { var item = Items.FirstOrDefault(x => x.Code == code); if (item is not null) Input = new() { Code = item.Code, Description = item.Description, WarehouseCode = item.WarehouseCode }; } }
    public async Task<IActionResult> OnPostSaveAsync(CancellationToken token) { if (ModelState.IsValid) { var result = await service.SaveAsync(new() { Code = Input.Code, Description = Input.Description, WarehouseCode = Input.WarehouseCode }, token); if (result.Succeeded) { await WriteAudit("catalog.return-reason-save", result.Code, "Succeeded", token); StatusMessage = "Motivo guardado."; return RedirectToPage(); } foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error); } await Load(token); return Page(); }
    public async Task<IActionResult> OnPostDeleteAsync(int code, CancellationToken token) { var deleted = await service.DeleteAsync(code, token); await WriteAudit("catalog.return-reason-delete", code, deleted ? "Succeeded" : "NotChanged", token); StatusMessage = deleted ? "Motivo eliminado." : "El motivo ya no existía."; return RedirectToPage(); }
    private async Task Load(CancellationToken token) { Items = await service.ListAsync(token); Warehouses = (await service.ListWarehousesAsync(token)).Select(x => new SelectListItem($"{x.Code} - {x.Name}", x.Code, x.Code == Input.WarehouseCode)).ToArray(); }
    private async Task WriteAudit(string operation, int code, string outcome, CancellationToken token) { var id = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), NumberStyles.None, CultureInfo.InvariantCulture, out var parsed) ? parsed : (int?)null; await audit.WriteAsync(id, User.Identity?.Name ?? "", options.Value.DefaultCompany, operation, "MotivoDevolucion", code.ToString(CultureInfo.InvariantCulture), outcome, HttpContext.TraceIdentifier, HttpContext.Connection.RemoteIpAddress?.ToString(), token); }
    public sealed class InputModel { public int Code { get; set; } [Required, StringLength(150), Display(Name = "Descripción")] public string Description { get; set; } = ""; [Required, StringLength(20), Display(Name = "Bodega SAP")] public string WarehouseCode { get; set; } = ""; }
}
