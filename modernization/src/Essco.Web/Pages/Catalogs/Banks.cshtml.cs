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
public sealed class BanksModel(BankService service, AuditService audit, IOptions<EsscoOptions> options) : PageModel
{
    [BindProperty] public InputModel Input { get; set; } = new();
    public IReadOnlyCollection<CompanyBank> Items { get; private set; } = [];
    [TempData] public string? StatusMessage { get; set; }

    public async Task OnGetAsync(CancellationToken token) => Items = await service.ListAsync(token);

    public async Task<IActionResult> OnPostSaveAsync(CancellationToken token)
    {
        if (ModelState.IsValid)
        {
            var result = await service.CreateAsync(new CompanyBank { Code = Input.Code, Name = Input.Name, Account = Input.Account }, token);
            if (result.Succeeded)
            {
                await LogAsync("catalog.bank-create", Input.Code, "Succeeded", token);
                StatusMessage = "Banco guardado.";
                return RedirectToPage();
            }
            foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error);
        }
        Items = await service.ListAsync(token);
        return Page();
    }

    public async Task<IActionResult> OnPostDeleteAsync(string code, CancellationToken token)
    {
        var changed = !string.IsNullOrWhiteSpace(code) && await service.DeleteAsync(code, token);
        await LogAsync("catalog.bank-delete", code, changed ? "Succeeded" : "NotChanged", token);
        StatusMessage = changed ? "Banco eliminado." : "El banco ya no existía.";
        return RedirectToPage();
    }

    private async Task LogAsync(string operation, string key, string result, CancellationToken token)
    {
        var userId = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), NumberStyles.None, CultureInfo.InvariantCulture, out var parsed) ? parsed : (int?)null;
        await audit.WriteAsync(userId, User.Identity?.Name ?? "", options.Value.DefaultCompany, operation, "BancosEssco", key, result, HttpContext.TraceIdentifier, HttpContext.Connection.RemoteIpAddress?.ToString(), token);
    }

    public sealed class InputModel
    {
        [Required, StringLength(50), Display(Name = "Código")] public string Code { get; set; } = "";
        [Required, StringLength(200), Display(Name = "Nombre")] public string Name { get; set; } = "";
        [Required, StringLength(100), Display(Name = "Cuenta asignada")] public string Account { get; set; } = "";
    }
}
