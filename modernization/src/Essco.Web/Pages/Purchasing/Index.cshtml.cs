using Essco.Application.Configuration;
using Essco.Application.Purchasing;
using Essco.Application.Security;
using Essco.Domain.Purchasing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
namespace Essco.Web.Pages.Purchasing;

[Authorize(Policy = Permissions.Billing)]
public sealed class IndexModel(PurchaseOrderService service, IOptions<EsscoOptions> options) : PageModel
{ [BindProperty(SupportsGet = true)] public int? Number { get; set; } [BindProperty(SupportsGet = true)] public string? Supplier { get; set; } [BindProperty(SupportsGet = true)] public DateOnly? From { get; set; } [BindProperty(SupportsGet = true)] public DateOnly? To { get; set; } [BindProperty(SupportsGet = true)] public string State { get; set; } = "pending"; public IReadOnlyCollection<PurchaseOrder> Items { get; private set; } = []; [TempData] public string? StatusMessage { get; set; } public async Task OnGetAsync(CancellationToken t) { bool? sap = State switch { "pending" => false, "sent" => true, _ => null }; Items = await service.ListAsync(new(Number, Supplier, From, To, sap), t); } public async Task<IActionResult> OnPostDispatchAsync(int number, CancellationToken t) { var r = await service.DispatchAsync(number, options.Value.Sap.CompanyDatabase, User.Identity?.Name ?? "web", t); StatusMessage = r.Succeeded ? $"Pedido {number} encolado para SAP ({r.Job!.Id})." : r.Error; return RedirectToPage(new { Number, Supplier, From, To, State }); } public async Task<IActionResult> OnPostCancelAsync(int number, CancellationToken t) { StatusMessage = await service.CancelAsync(number, t) ? $"Pedido {number} anulado." : "No fue posible anular el pedido."; return RedirectToPage(); } }
