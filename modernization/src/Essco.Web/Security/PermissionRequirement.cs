using System.Security.Claims;
using Essco.Application.Security;
using Microsoft.AspNetCore.Authorization;

namespace Essco.Web.Security;

public sealed record PermissionRequirement(string Permission) : IAuthorizationRequirement;

public sealed class PermissionAuthorizationHandler : AuthorizationHandler<PermissionRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        var roles = context.User.FindAll(ClaimTypes.Role).Select(claim => claim.Value);
        if (roles.Any(role => LegacyRolePermissions.HasPermission(role, requirement.Permission)))
            context.Succeed(requirement);
        return Task.CompletedTask;
    }
}
