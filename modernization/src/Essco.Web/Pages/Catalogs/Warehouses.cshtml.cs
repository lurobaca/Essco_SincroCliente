using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Security.Claims;
using Essco.Application.Auditing;
using Essco.Application.Catalogs;
using Essco.Application.Configuration;
using Essco.Application.Security;
using Essco.Domain.Catalogs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;

namespace Essco.Web.Pages.Catalogs;

[Authorize(Policy = Permissions.Catalogs)]
public sealed class WarehousesModel(WarehouseService service, AuditService audit, IOptions<EsscoOptions> options) : PageModel
{
    [BindProperty] public InputModel Input { get; set; } = new();
    public IReadOnlyCollection<PickingWarehouse> Items { get; private set; } = [];
    [TempData] public string? StatusMessage { get; set; }

    public async Task OnGetAsync(int? id, CancellationToken token)
    {
        Items = await service.ListAsync(token);
        var item = id is null ? null : Items.FirstOrDefault(x => x.Id == id);
        Input = item is null
            ? new InputModel { Id = await service.NextIdAsync(token), IsNew = true }
            : new InputModel { Id = item.Id, Name = item.Name, Location = item.Location, Racks = item.Racks, Columns = item.Columns, IsDefault = item.IsDefault, IsNew = false };
    }

    public async Task<IActionResult> OnPostSaveAsync(CancellationToken token)
    {
        if (ModelState.IsValid)
        {
            var warehouse = new PickingWarehouse { Id = Input.Id, Name = Input.Name, Location = Input.Location, Racks = Input.Racks, Columns = Input.Columns, IsDefault = Input.IsDefault };
            var result = await service.SaveAsync(warehouse, Input.IsNew, token);
            if (result.Succeeded)
            {
                await LogAsync("catalog.warehouse-save", Input.Id, "Succeeded", token);
                StatusMessage = "Bodega guardada.";
                return RedirectToPage();
            }
            ModelState.AddModelError(string.Empty, result.Error ?? "No fue posible guardar la bodega.");
        }
        Items = await service.ListAsync(token);
        return Page();
    }

    public async Task<IActionResult> OnPostDeleteAsync(int id, CancellationToken token)
    {
        var result = await service.DeleteAsync(id, token);
        await LogAsync("catalog.warehouse-delete", id, result.Succeeded ? "Succeeded" : "Rejected", token);
        StatusMessage = result.Succeeded ? "Bodega eliminada." : result.Error;
        return RedirectToPage();
    }

    private async Task LogAsync(string operation, int id, string result, CancellationToken token)
    {
        var userId = int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), NumberStyles.None, CultureInfo.InvariantCulture, out var parsed) ? parsed : (int?)null;
        await audit.WriteAsync(userId, User.Identity?.Name ?? "", options.Value.DefaultCompany, operation, "Picking_Bodega", id.ToString(CultureInfo.InvariantCulture), result, HttpContext.TraceIdentifier, HttpContext.Connection.RemoteIpAddress?.ToString(), token);
    }

    public sealed class InputModel
    {
        [Range(1, int.MaxValue), Display(Name = "Código")] public int Id { get; set; }
        public bool IsNew { get; set; } = true;
        [Required, StringLength(150), Display(Name = "Nombre")] public string Name { get; set; } = "";
        [Required, StringLength(250), Display(Name = "Ubicación")] public string Location { get; set; } = "";
        [Range(1, 10000), Display(Name = "Racks")] public int Racks { get; set; } = 1;
        [Range(1, 10000), Display(Name = "Columnas")] public int Columns { get; set; } = 1;
        [Display(Name = "Bodega predeterminada")] public bool IsDefault { get; set; }
    }
}
