using Essco.Application.Inventory;
using Essco.Application.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Essco.Web.Pages.Inventory;

[Authorize(Policy = Permissions.Warehouse)]
public sealed class CompleteCountModel(IInventoryCountCompletion completion) : PageModel
{
    [BindProperty] public string Group { get; set; } = "";
    [BindProperty] public int Number { get; set; } = 1;
    public void OnGet() { }
    public async Task<IActionResult> OnPostAsync(int id, CancellationToken token)
    {
        if (!ModelState.IsValid) return Page();
        if (!await completion.CompleteAsync(id, Group, Number, token))
        {
            ModelState.AddModelError("", "No se pudo finalizar. Compruebe el grupo, el conteo activo y las líneas pendientes.");
            return Page();
        }
        return RedirectToPage("Compare", new { id, Group });
    }
}
