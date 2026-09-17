using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Essco.Portal.Pages.Account;
[Authorize]
public sealed class LogoutModel : PageModel
{
    public IActionResult OnGet()=>RedirectToPage("/Portal/Index");
    public async Task<IActionResult> OnPostAsync() { await HttpContext.SignOutAsync(); return RedirectToPage("/Index"); }
}
