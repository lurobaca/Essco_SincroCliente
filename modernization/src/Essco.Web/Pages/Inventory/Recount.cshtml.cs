using Essco.Application.Inventory;
using Essco.Application.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Essco.Web.Pages.Inventory;

[Authorize(Policy = Permissions.Warehouse)]
public sealed class RecountModel(InventoryService service, IInventoryRecountRepository repository) : PageModel
{
    [BindProperty] public string Group { get; set; } = "";
    [BindProperty] public int Previous { get; set; } = 3;
    [BindProperty] public string ItemCodes { get; set; } = "";
    public async Task<IActionResult> OnGetAsync(int id, CancellationToken token) =>
        await service.GetAsync(id, token) is null ? NotFound() : Page();
    public async Task<IActionResult> OnPostAsync(int id, CancellationToken token)
    {
        if (!ModelState.IsValid) return Page();
        var items = (ItemCodes ?? "").Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        var request = new InventoryRecountRequest(id, Group, Previous, items);
        if (!request.IsValid)
        {
            ModelState.AddModelError("", "Indique grupo, último conteo (desde 3) y códigos únicos, uno por línea.");
            return Page();
        }
        if (!await repository.CreateAsync(request, token))
        {
            ModelState.AddModelError("", "No se creó el reconteo. El inventario debe estar abierto y el conteo anterior completo, finalizado y sin sucesores. Compruebe los artículos.");
            return Page();
        }
        TempData["StatusMessage"] = $"Conteo {Previous + 1} creado. Las líneas seleccionadas quedan pendientes de captura.";
        return RedirectToPage("Detail", new { id, Group });
    }
}
