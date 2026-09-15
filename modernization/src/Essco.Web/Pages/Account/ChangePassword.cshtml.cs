using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Security.Claims;
using Essco.Application.Security;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Essco.Web.Pages.Account;

[Authorize]
public sealed class ChangePasswordModel(PasswordChangeService passwordChangeService) : PageModel
{
    [BindProperty]
    public InputModel Input { get; set; } = new();

    public async Task<IActionResult> OnPostAsync(CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid) return Page();
        if (!int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), NumberStyles.None, CultureInfo.InvariantCulture, out var userId) ||
            string.IsNullOrWhiteSpace(User.Identity?.Name))
            return Challenge();

        var result = await passwordChangeService.ChangeAsync(
            userId, User.Identity.Name, Input.CurrentPassword, Input.NewPassword, cancellationToken);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors) ModelState.AddModelError(string.Empty, error);
            return Page();
        }

        var identity = (ClaimsIdentity)User.Identity;
        var oldClaim = identity.FindFirst("password_change_required");
        if (oldClaim is not null) identity.RemoveClaim(oldClaim);
        identity.AddClaim(new Claim("password_change_required", "false"));
        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, User);
        return RedirectToPage("/Index");
    }

    public sealed class InputModel
    {
        [Required, DataType(DataType.Password), Display(Name = "Contraseña actual")]
        public string CurrentPassword { get; set; } = "";

        [Required, DataType(DataType.Password), Display(Name = "Contraseña nueva")]
        public string NewPassword { get; set; } = "";

        [Required, DataType(DataType.Password), Compare(nameof(NewPassword)), Display(Name = "Confirmar contraseña")]
        public string ConfirmPassword { get; set; } = "";
    }
}
