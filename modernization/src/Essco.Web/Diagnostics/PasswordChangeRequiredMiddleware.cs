namespace Essco.Web.Diagnostics;

public sealed class PublicStaticAssetMetadata { }

public sealed class PasswordChangeRequiredMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var requiresChange = context.User.Identity?.IsAuthenticated == true &&
            string.Equals(context.User.FindFirst("password_change_required")?.Value, "true", StringComparison.OrdinalIgnoreCase);
        var allowedPath = context.Request.Path.StartsWithSegments("/Account/ChangePassword") ||
            context.Request.Path.StartsWithSegments("/Account/Logout") ||
            context.Request.Path.StartsWithSegments("/health");

        var publicAsset = context.GetEndpoint()?.Metadata.GetMetadata<PublicStaticAssetMetadata>() is not null;
        if (requiresChange && !allowedPath && !publicAsset)
        {
            context.Response.Redirect("/Account/ChangePassword");
            return;
        }

        await next(context);
    }
}
