using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System.Security.Claims;
using Essco.Application.Auditing;
using Essco.Application.Configuration;
using Microsoft.Extensions.Options;

namespace Essco.Web.Pages.Account;

[Authorize]
public sealed class LogoutModel(AuditService auditService, IOptions<EsscoOptions> options) : PageModel
{
    public IActionResult OnGet() => RedirectToPage("/Index");

    public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
    {
        _ = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), NumberStyles.None, CultureInfo.InvariantCulture, out var userId);
        await auditService.WriteAsync(
            userId == 0 ? null : userId,
            User.Identity?.Name,
            options.Value.DefaultCompany,
            "security.logout",
            "UserAccount",
            userId == 0 ? null : userId.ToString(CultureInfo.InvariantCulture),
            "Succeeded",
            HttpContext.TraceIdentifier,
            HttpContext.Connection.RemoteIpAddress?.ToString(),
            cancellationToken);
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return RedirectToPage("/Account/Login");
    }
}
