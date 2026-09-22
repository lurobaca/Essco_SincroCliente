using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.RateLimiting;
namespace Essco.Portal.Pages.Account;

[EnableRateLimiting("login")]
public sealed class LoginModel(PortalStore store, ILogger<LoginModel> logger) : PageModel
{
    [BindProperty, Required, EmailAddress, StringLength(254)] public string Email { get; set; } = "";
    [BindProperty, Required, StringLength(256)] public string Password { get; set; } = "";
    public bool Configured => store.Configured;
    public async Task<IActionResult> OnPostAsync(CancellationToken token)
    {
        if (!Request.IsHttps) { ModelState.AddModelError("", "Utilice la dirección HTTPS del portal."); return Page(); }
        if (!ModelState.IsValid) return Page();
        PortalUser? user;
        try { user = await store.Authenticate(Email, Password, token); }
        catch (Microsoft.Data.SqlClient.SqlException ex) { logger.LogWarning("Portal SQL no disponible. Código {Code}", ex.Number); ModelState.AddModelError("", "El acceso no está disponible temporalmente."); return Page(); }
        if (user is null) { ModelState.AddModelError("", "No se pudo iniciar sesión. Compruebe sus credenciales o espere unos minutos si realizó varios intentos."); return Page(); }
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(new ClaimsIdentity([
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),new Claim(ClaimTypes.Name,user.Name)
            ], CookieAuthenticationDefaults.AuthenticationScheme)));
        return RedirectToPage("/Portal/Index");
    }
}
