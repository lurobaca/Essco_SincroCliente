using System.Security.Claims;
using Essco.Web.Diagnostics;
namespace Essco.Tests.Unit.Security;

public sealed class PasswordChangeRequiredMiddlewareTests
{
    [Theory]
    [InlineData("/css/site.css", true, true)]
    [InlineData("/lib/bootstrap/dist/css/bootstrap.min.css", true, true)]
    [InlineData("/js/site.js", true, true)]
    [InlineData("/Inventory", false, false)]
    [InlineData("/Inventory/fake.css", false, false)]
    [InlineData("/Account/ChangePassword", false, true)]
    [InlineData("/Account/Logout", false, true)]
    public async Task Allows_registered_assets_but_keeps_business_pages_blocked(string path,bool asset,bool expectedNext)
    {
        var context=new DefaultHttpContext();
        context.Request.Path=path;
        context.User=new ClaimsPrincipal(new ClaimsIdentity([new Claim("password_change_required","true")],"test"));
        if(asset) context.SetEndpoint(new Endpoint(_=>Task.CompletedTask,new EndpointMetadataCollection(new PublicStaticAssetMetadata()),"asset"));
        var called=false;
        var middleware=new PasswordChangeRequiredMiddleware(_=>{called=true;return Task.CompletedTask;});
        await middleware.InvokeAsync(context);
        Assert.Equal(expectedNext,called);
        if(!expectedNext)
        {
            Assert.Equal(302,context.Response.StatusCode);
            Assert.Equal("/Account/ChangePassword",context.Response.Headers.Location.ToString());
        }
    }
}
