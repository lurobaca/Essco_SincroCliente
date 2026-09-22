using Essco.Application.Inventory;
using Essco.Application.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Essco.Web.Pages.Inventory;

[Authorize(Policy = Permissions.Warehouse)]
public sealed class ConsolidateModel(InventoryService service, IInventoryConsolidationRepository repository) : PageModel
{
    [BindProperty] public string Supplier { get; set; } = "";
    [BindProperty] public string Group { get; set; } = "";
    [BindProperty] public string Responsible { get; set; } = "";
    [BindProperty] public string? Companion { get; set; }
    [BindProperty] public decimal Threshold { get; set; }
    public async Task<IActionResult> OnGetAsync(int id, CancellationToken token) =>
        await service.GetAsync(id, token) is null ? NotFound() : Page();
    public async Task<IActionResult> OnPostAsync(int id, CancellationToken token)
    {
        if (!ModelState.IsValid) return Page();
        var request = new InventoryConsolidationRequest(id, Supplier, Group, Responsible, Companion ?? "", Threshold);
        if (!request.IsValid || !await repository.CreateAsync(request, token))
        {
            ModelState.AddModelError("", "No se pudo unificar. Revise proveedor, responsable, grupo nuevo de 2 a 50 caracteres, umbral no negativo, últimos conteos finalizados y datos completos. El proveedor no debe estar unificado.");
            return Page();
        }
        TempData["StatusMessage"] = "Grupo unificado creado con conteo 4. Capture las diferencias pendientes; puede abrir reconteos posteriores.";
        return RedirectToPage("Detail", new { id, Group });
    }
}
