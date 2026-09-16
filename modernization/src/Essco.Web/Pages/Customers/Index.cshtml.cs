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

[Authorize(Policy = Permissions.Customers)]
public sealed class IndexModel(CustomerChangeService service, AuditService audit, IOptions<EsscoOptions> options) : PageModel
{
    [BindProperty(SupportsGet = true)] public string? Term { get; set; }
    [BindProperty(SupportsGet = true)] public bool ByName { get; set; }
    [BindProperty(SupportsGet = true)] public bool Approved { get; set; }
    [BindProperty(SupportsGet = true)] public CustomerChangeState State { get; set; } = CustomerChangeState.Modified;
    [BindProperty(SupportsGet = true)] public string? Agent { get; set; }
    [BindProperty(SupportsGet = true)] public DateOnly? From { get; set; }
    [BindProperty(SupportsGet = true)] public DateOnly? To { get; set; }
    [BindProperty(SupportsGet = true)] public int PageNumber { get; set; } = 1;
    public CustomerSearchResult Result { get; private set; } = new([], 0);
    public int PageSize => 50;
    public int TotalPages => Math.Max(1, (int)Math.Ceiling(Result.Total / (double)PageSize));
    [TempData] public string? StatusMessage { get; set; }

    public async Task OnGetAsync(CancellationToken cancellationToken) => await LoadAsync(cancellationToken);

    public async Task<IActionResult> OnPostApproveAsync(long id, CancellationToken cancellationToken)
    {
        var changed = await service.ApproveAsync(id, cancellationToken);
        var userId = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), NumberStyles.None, CultureInfo.InvariantCulture, out var parsed) ? parsed : (int?)null;
        await audit.WriteAsync(userId, User.Identity?.Name ?? "", options.Value.DefaultCompany,
            "customers.change-approve", "ClientesModificados", id.ToString(CultureInfo.InvariantCulture),
            changed ? "Succeeded" : "NotChanged", HttpContext.TraceIdentifier,
            HttpContext.Connection.RemoteIpAddress?.ToString(), cancellationToken);
        StatusMessage = changed ? "La solicitud fue aprobada." : "La solicitud ya no estaba pendiente.";
        return RedirectToPage(new { Term, ByName, Approved, State, Agent, From, To, PageNumber });
    }

    private async Task LoadAsync(CancellationToken token)
    {
        if (From is not null && To is not null && From > To) ModelState.AddModelError(string.Empty, "La fecha inicial no puede ser posterior a la final.");
        if (!ModelState.IsValid) return;
        Result = await service.SearchAsync(new(Approved, State, Term, ByName, Agent, From, To, Math.Max(1, PageNumber), PageSize), token);
    }
}
