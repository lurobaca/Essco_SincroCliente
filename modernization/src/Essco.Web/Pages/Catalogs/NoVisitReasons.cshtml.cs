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

[Authorize(Policy = Permissions.Catalogs)]
public sealed class NoVisitReasonsModel(NoVisitReasonService service, AuditService audit, IOptions<EsscoOptions> options) : PageModel
{
    [BindProperty] public InputModel Input { get; set; } = new();
    public IReadOnlyCollection<NoVisitReason> Items { get; private set; } = [];
    [TempData] public string? StatusMessage { get; set; }

    public async Task OnGetAsync(int? code, CancellationToken token)
    {
        Items = await service.ListAsync(token);
        var item = code is null ? null : Items.FirstOrDefault(x => x.Code == code);
        if (item is not null) Input = new InputModel { Code = item.Code, Reason = item.Reason };
    }

    public async Task<IActionResult> OnPostSaveAsync(CancellationToken token)
    {
        if (ModelState.IsValid)
        {
            var result = await service.SaveAsync(new NoVisitReason { Code = Input.Code, Reason = Input.Reason }, token);
            if (result.Succeeded)
            {
                await LogAsync("catalog.no-visit-reason-save", result.Code, "Succeeded", token);
                StatusMessage = "Razón de no visita guardada.";
                return RedirectToPage();
            }
            foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error);
        }
        Items = await service.ListAsync(token);
        return Page();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int code, CancellationToken token)
    {
        var changed = await service.DeleteAsync(code, token);
        await LogAsync("catalog.no-visit-reason-delete", code, changed ? "Succeeded" : "NotChanged", token);
        StatusMessage = changed ? "Razón de no visita eliminada." : "La razón ya no existía.";
        return RedirectToPage();
    }

    private async Task LogAsync(string operation, int code, string result, CancellationToken token)
    {
        var userId = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), NumberStyles.None, CultureInfo.InvariantCulture, out var parsed) ? parsed : (int?)null;
        await audit.WriteAsync(userId, User.Identity?.Name ?? "", options.Value.DefaultCompany, operation, "Razones_NoVisita", code.ToString(CultureInfo.InvariantCulture), result, HttpContext.TraceIdentifier, HttpContext.Connection.RemoteIpAddress?.ToString(), token);
    }

    public sealed class InputModel
    {
        public int Code { get; set; }
        [Required, StringLength(250), Display(Name = "Razón")] public string Reason { get; set; } = "";
    }
}
