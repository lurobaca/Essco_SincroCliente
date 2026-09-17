using Essco.Application.Inventory;
using Essco.Application.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Essco.Web.Pages.Inventory;

[Authorize(Policy = Permissions.Warehouse)]
public sealed class SupplierSummaryModel(InventoryService service) : PageModel
{
    [BindProperty(SupportsGet = true)] public string Supplier { get; set; } = "";
    [BindProperty(SupportsGet = true)] public decimal Threshold { get; set; }
    public IReadOnlyCollection<InventorySupplierLine> Lines { get; private set; } = [];
    public async Task<IActionResult> OnGetAsync(int id, CancellationToken token)
    {
        if (await service.GetAsync(id, token) is null) return NotFound();
        if (Threshold < 0) ModelState.AddModelError("", "El umbral no puede ser negativo.");
        if (ModelState.IsValid && !string.IsNullOrWhiteSpace(Supplier))
            Lines = InventorySupplierSummary.Calculate(id, Supplier.Trim(),
                await service.ListCountsAsync(id, null, token), await service.ListItemsAsync(id, token));
        return Page();
    }
}
