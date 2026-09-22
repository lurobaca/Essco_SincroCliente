using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace Essco.Portal.Pages.Portal;

[Authorize]
public sealed class IndexModel(PortalStore store, IConfiguration configuration) : PageModel
{
    public IReadOnlyList<Organization> Organizations { get; private set; } = [];
    public IReadOnlyList<PortalApplication> Applications { get; private set; } = [];
    public Organization? Selected { get; private set; }
    public string? ApplicationUrl(PortalApplication application) => application.Code switch
    {
        "syncro-cliente" => configuration["ExternalApplications:SyncroClienteUrl"],
        _ => null
    };
    public async Task<IActionResult> OnGetAsync(Guid? organization, CancellationToken token)
    {
        if (!Guid.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out var userId)) return Challenge();
        Organizations = await store.Organizations(userId, token);
        Selected = organization is null ? Organizations.FirstOrDefault() : Organizations.SingleOrDefault(x => x.Id == organization);
        if (organization is not null && Selected is null) return Forbid();
        if (Selected is not null) Applications = await store.Applications(userId, Selected.Id, token);
        return Page();
    }
}
