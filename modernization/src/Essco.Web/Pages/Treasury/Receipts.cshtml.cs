using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Security.Claims;
using Essco.Application.Auditing;
using Essco.Application.Configuration;
using Essco.Application.Security;
using Essco.Application.Treasury;
using Essco.Domain.Treasury;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Essco.Web.Pages.Treasury;

[Authorize(Policy = Permissions.Cash)]
public sealed class ReceiptsModel(IncomingReceiptService service, AuditService audit, IOptions<EsscoOptions> options) : PageModel
{
    [BindProperty(SupportsGet = true)] public FilterModel Filter { get; set; } = new();
    [BindProperty] public LinkModel Link { get; set; } = new();
    public IReadOnlyCollection<IncomingReceipt> Items { get; private set; } = [];
    [TempData] public string? StatusMessage { get; set; }
    public async Task OnGetAsync(CancellationToken token) => await LoadAsync(token);
    public async Task<IActionResult> OnPostLinkAsync(CancellationToken token) => await DispatchAsync(false, token);
    public async Task<IActionResult> OnPostUnlinkAsync(int docEntry, CancellationToken token)
    { Link = new() { DocEntry = docEntry }; return await DispatchAsync(true, token); }
    private async Task<IActionResult> DispatchAsync(bool unlink, CancellationToken token)
    {
        if (!unlink && !ModelState.IsValid) { await LoadAsync(token); return Page(); }
        var result = await service.DispatchAsync(Link.DocEntry, Link.CollectorCode, Link.LiquidationNumber, unlink,
            options.Value.DefaultCompany, User.Identity?.Name ?? "", token);
        if (!result.Succeeded) { ModelState.AddModelError(string.Empty, result.Error ?? "No fue posible encolar la operación."); await LoadAsync(token); return Page(); }
        await WriteAuditAsync(unlink ? "treasury.receipt-unlink" : "treasury.receipt-link", Link.DocEntry, token);
        StatusMessage = $"Operación encolada para SAP. Trabajo: {result.Job!.Id}"; return RedirectToPage(Filter.RouteValues());
    }
    private async Task LoadAsync(CancellationToken token)
    { var result = await service.ListAsync(Filter.ToDomain(), token); Items = result.Items; foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error); }
    private async Task WriteAuditAsync(string operation, int id, CancellationToken token)
    { var userId = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), NumberStyles.None, CultureInfo.InvariantCulture, out var parsed) ? parsed : (int?)null; await audit.WriteAsync(userId, User.Identity?.Name ?? "", options.Value.DefaultCompany, operation, "ORCT", id.ToString(CultureInfo.InvariantCulture), "Queued", HttpContext.TraceIdentifier, HttpContext.Connection.RemoteIpAddress?.ToString(), token); }
    public sealed class FilterModel
    {
        [DataType(DataType.Date)] public DateOnly? From { get; set; }
        [DataType(DataType.Date)] public DateOnly? To { get; set; }
        public string? Collector { get; set; }
        public string? Liquidation { get; set; }
        public int? Number { get; set; }
        public bool OnlyUnlinked { get; set; }
        public IncomingReceiptFilter ToDomain() => new(From, To, Collector, Liquidation, Number, OnlyUnlinked);
        public IReadOnlyDictionary<string, object?> RouteValues() => new Dictionary<string, object?> { { "Filter.From", From }, { "Filter.To", To }, { "Filter.Collector", Collector }, { "Filter.Liquidation", Liquidation }, { "Filter.Number", Number }, { "Filter.OnlyUnlinked", OnlyUnlinked } };
    }
    public sealed class LinkModel
    { [Range(1, int.MaxValue)] public int DocEntry { get; set; } [Required, StringLength(50)] public string CollectorCode { get; set; } = ""; [Required, StringLength(50)] public string LiquidationNumber { get; set; } = ""; }
}
