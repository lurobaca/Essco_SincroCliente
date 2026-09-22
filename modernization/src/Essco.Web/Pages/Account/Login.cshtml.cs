using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Essco.Application.Security;
using Essco.Application.Auditing;
using Essco.Application.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Essco.Web.Pages.Account;

[AllowAnonymous]
public sealed class LoginModel(
    Essco.Application.Security.AuthenticationService authenticationService,
    AuditService auditService,
    IOptions<EsscoOptions> options, IConfiguration configuration) : PageModel
{
    public bool AccessConfigured => options.Value.SqlServer.Enabled && !string.IsNullOrWhiteSpace(configuration.GetConnectionString(options.Value.SqlServer.ConnectionStringName));
    [BindProperty]
    public InputModel Input { get; set; } = new();

    [BindProperty(SupportsGet = true)]
    public string? ReturnUrl { get; set; }

    public IActionResult OnGet()
    {
        if (User.Identity?.IsAuthenticated == true) return RedirectToPage("/Index");
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
    {
        if (!AccessConfigured || !Request.IsHttps)
        {
            ModelState.AddModelError(string.Empty, "Se requiere configurar el acceso y abrir la aplicación por HTTPS.");
            return Page();
        }
        if (!ModelState.IsValid) return Page();

        var result = await authenticationService.AuthenticateAsync(
            new(Input.Username, Input.Password), cancellationToken);
        await auditService.WriteAsync(
            result.UserId,
            result.Username ?? Input.Username,
            options.Value.DefaultCompany,
            "security.login",
            "UserAccount",
            result.UserId?.ToString(System.Globalization.CultureInfo.InvariantCulture),
            result.Status.ToString(),
            HttpContext.TraceIdentifier,
            HttpContext.Connection.RemoteIpAddress?.ToString(),
            cancellationToken);
        if (result.Status != AuthenticationStatus.Succeeded)
        {
            ModelState.AddModelError(string.Empty,
                result.Status == AuthenticationStatus.LockedOut
                    ? "La cuenta está temporalmente bloqueada. Intente más tarde."
                    : "Usuario o contraseña incorrectos.");
            return Page();
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, result.UserId!.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)),
            new(ClaimTypes.Name, result.Username!),
            new("display_name", result.DisplayName ?? result.Username!),
            new(ClaimTypes.Role, result.Role ?? "SinRol"),
            new("password_change_required", result.MustChangePassword ? "true" : "false")
        };
        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme)),
            new AuthenticationProperties { IsPersistent = false, AllowRefresh = true });

        if (result.MustChangePassword) return RedirectToPage("/Account/ChangePassword");
        return LocalRedirect(Url.IsLocalUrl(ReturnUrl) ? ReturnUrl! : "/");
    }

    public sealed class InputModel
    {
        [Required, Display(Name = "Usuario")]
        public string Username { get; set; } = "";

        [Required, DataType(DataType.Password), Display(Name = "Contraseña")]
        public string Password { get; set; } = "";
    }
}
