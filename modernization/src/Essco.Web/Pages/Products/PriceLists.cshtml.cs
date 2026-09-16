using System.ComponentModel.DataAnnotations;
using Essco.Application.Products;
using Essco.Application.Security;
using Essco.Domain.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Essco.Web.Pages.Products;

[Authorize(Policy = Permissions.Billing)]
public sealed class PriceListsModel(ProductService service) : PageModel
{
    [BindProperty] public InputModel Input { get; set; } = new();
    public IReadOnlyCollection<PriceList> Items { get; private set; } = [];
    [TempData] public string? StatusMessage { get; set; }

    public async Task OnGetAsync(int? edit, CancellationToken token)
    {
        Items = await service.ListPriceListsAsync(token);
        var item = Items.FirstOrDefault(x => x.Id == edit);
        if (item is not null) Input = InputModel.From(item);
    }

    public async Task<IActionResult> OnPostSaveAsync(CancellationToken token)
    {
        if (ModelState.IsValid)
        {
            var result = await service.SavePriceListAsync(Input.Domain(), Input.IsNew, token);
            if (result.Succeeded)
            {
                StatusMessage = $"Lista de precios {result.Id} guardada.";
                return RedirectToPage();
            }
            ModelState.AddModelError(string.Empty, result.Error!);
        }
        Items = await service.ListPriceListsAsync(token);
        return Page();
    }

    public async Task<IActionResult> OnPostStatusAsync(int id, bool inactive, CancellationToken token)
    {
        StatusMessage = await service.SetPriceListInactiveAsync(id, inactive, token)
            ? inactive ? "Lista inactivada." : "Lista activada."
            : "La lista dejó de estar disponible.";
        return RedirectToPage();
    }

    public sealed class InputModel
    {
        public bool IsNew { get; set; } = true;
        public int Id { get; set; }
        [Required, StringLength(100)] public string Name { get; set; } = "";
        public bool IsInactive { get; set; }
        public PriceList Domain() => new(Id, Name.Trim(), IsInactive);
        public static InputModel From(PriceList x) => new() { IsNew = false, Id = x.Id, Name = x.Name, IsInactive = x.IsInactive };
    }
}
