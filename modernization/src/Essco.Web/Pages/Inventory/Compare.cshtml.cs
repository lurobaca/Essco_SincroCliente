using Essco.Application.Inventory;
using Essco.Application.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Essco.Web.Pages.Inventory;

[Authorize(Policy = Permissions.Warehouse)]
public sealed class CompareModel(InventoryService service, IInventoryCrossingRepository crossing) : PageModel
{
    [BindProperty(SupportsGet = true)] public string Group { get; set; } = "";
    [BindProperty(SupportsGet = true)] public int First { get; set; } = 1;
    [BindProperty(SupportsGet = true)] public int Second { get; set; } = 2;
    [BindProperty(SupportsGet = true)] public decimal Threshold { get; set; }
    public IReadOnlyCollection<InventoryComparisonLine> Lines { get; private set; } = [];
    [TempData] public string? StatusMessage { get; set; }
    public async Task<IActionResult> OnPostCrossAsync(int id, CancellationToken token)
    {
        if (!ModelState.IsValid || First != 1 || Second != 2 || Threshold < 0 || string.IsNullOrWhiteSpace(Group))
            return BadRequest("El cruce requiere grupo, conteos 1 y 2 y umbral no negativo.");
        StatusMessage = await crossing.CrossAsync(id, Group, Threshold, token)
            ? "Conteo 3 generado."
            : "No se generó el cruce: compruebe que 1 y 2 estén finalizados, que los datos estén completos y que no exista ya el conteo 3.";
        return RedirectToPage(new { id, Group, First, Second, Threshold });
    }
    public async Task<IActionResult> OnGetAsync(int id, CancellationToken token)
    {
        if (await service.GetAsync(id, token) is null) return NotFound();
        if (!ModelState.IsValid) return Page();
        if (Threshold < 0 || First <= 0 || Second <= 0 || First == Second)
        {
            ModelState.AddModelError("", "Revise los números de conteo y el umbral no negativo.");
            return Page();
        }
        if (!string.IsNullOrWhiteSpace(Group))
            Lines = InventoryComparison.Compare(await service.ListCountsAsync(id, Group, token),
                await service.ListItemsAsync(id, token), Group, First, Second);
        return Page();
    }
}
