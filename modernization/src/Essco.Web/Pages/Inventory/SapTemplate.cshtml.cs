using Essco.Application.Inventory;
using Essco.Application.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Essco.Web.Pages.Inventory;
[Authorize(Policy=Permissions.Warehouse)]
public sealed class SapTemplateModel(InventoryService service):PageModel
{
    public async Task<IActionResult> OnGetAsync(int id,CancellationToken token)
    {
        var inventory=await service.GetAsync(id,token);
        if(inventory is null) return NotFound();
        if(!inventory.Closed) return BadRequest("Finalice y cierre el inventario antes de exportar las cantidades aceptadas.");
        var items=await service.ListItemsAsync(id,token);
        try
        {
            return File(InventorySapTemplate.Create(items),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",$"inventario-{id}-sap.xlsx");
        }
        catch(ArgumentException) { return BadRequest("Revise las cantidades y códigos de los artículos antes de exportar."); }
    }
}
