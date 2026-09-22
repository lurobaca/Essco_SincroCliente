using Essco.Application.Security;

namespace Essco.Tests.Unit.Security;

public sealed class ErpNavigationCatalogTests
{
    [Fact]
    public void Catalog_preserves_complete_functional_menu_inventory()
    {
        var leaves = ErpNavigationCatalog.Descendants().Where(x => x.Items.Count == 0).ToArray();

        Assert.Equal(80, leaves.Length);
        Assert.Equal(45, leaves.Count(x => x.State == NavigationMigrationState.Partial));
        Assert.Equal(32, leaves.Count(x => x.State == NavigationMigrationState.NotMigrated));
        Assert.Equal(3, leaves.Count(x => x.State == NavigationMigrationState.ObsoleteReview));
    }

    [Fact]
    public void Only_partial_options_have_real_routes_and_permissions()
    {
        var leaves = ErpNavigationCatalog.Descendants().Where(x => x.Items.Count == 0).ToArray();

        Assert.All(leaves.Where(x => x.IsNavigable), x =>
        {
            Assert.NotNull(x.Page);
            Assert.StartsWith("/", x.Page);
            Assert.Contains(x.Permission, Permissions.All);
        });
        Assert.All(leaves.Where(x => !x.IsNavigable), x => Assert.Null(x.Page));
    }

    [Fact]
    public void Every_menu_node_has_traced_functional_iconography()
    {
        var nodes = ErpNavigationCatalog.Descendants().ToArray();

        Assert.Equal(97, nodes.Select(x => x.OriginalControl).Distinct().Count());
        Assert.All(nodes, node =>
        {
            Assert.False(string.IsNullOrWhiteSpace(node.Icon.Name));
            Assert.False(string.IsNullOrWhiteSpace(node.Icon.Function));
            Assert.False(string.IsNullOrWhiteSpace(node.Icon.Rationale));
        });
    }
}
