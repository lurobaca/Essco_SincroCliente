using Essco.Application.Security;

namespace Essco.Tests.Unit.Security;

public sealed class LegacyRolePermissionsTests
{
    [Fact]
    public void SuperUser_HasEveryKnownPermission()
    {
        Assert.All(Permissions.All, permission =>
            Assert.True(LegacyRolePermissions.HasPermission(LegacyRoles.SuperUser, permission)));
    }

    [Theory]
    [InlineData(LegacyRoles.Billing, Permissions.Billing, true)]
    [InlineData(LegacyRoles.Billing, Permissions.Users, false)]
    [InlineData(LegacyRoles.Administration, Permissions.Users, true)]
    [InlineData(LegacyRoles.Warehouse, Permissions.Warehouse, true)]
    [InlineData(LegacyRoles.Warehouse, Permissions.Payroll, false)]
    [InlineData(LegacyRoles.Reception, Permissions.Billing, true)]
    [InlineData("Desconocido", Permissions.Reports, false)]
    public void Mapping_MatchesDocumentedLegacyMenu(string role, string permission, bool expected)
    {
        Assert.Equal(expected, LegacyRolePermissions.HasPermission(role, permission));
    }
}
