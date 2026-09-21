using Essco.Application.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Essco.Web.Navigation;

public sealed class ErpNavigationViewComponent(IAuthorizationService authorization) : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        var groups = new List<NavigationOption>();
        foreach (var group in ErpNavigationCatalog.Groups)
        {
            var visible = await FilterAsync(group);
            if (visible is not null) groups.Add(visible);
        }
        return View(groups);
    }

    private async Task<NavigationOption?> FilterAsync(NavigationOption option)
    {
        if (option.Items.Count > 0)
        {
            var children = new List<NavigationOption>();
            foreach (var child in option.Items)
            {
                var visible = await FilterAsync(child);
                if (visible is not null) children.Add(visible);
            }
            return children.Count == 0 ? null : option with { Children = children };
        }

        if (!option.IsNavigable || option.Permission is null) return option;
        return (await authorization.AuthorizeAsync(UserClaimsPrincipal, option.Permission)).Succeeded ? option : null;
    }
}
