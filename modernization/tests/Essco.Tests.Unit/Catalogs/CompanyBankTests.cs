using Essco.Domain.Catalogs;

namespace Essco.Tests.Unit.Catalogs;

public sealed class CompanyBankTests
{
    [Fact]
    public void Validate_RequiresAllFields()
    {
        var errors = new CompanyBank { Code = "", Name = "", Account = "" }.Validate();
        Assert.Equal(3, errors.Count);
    }

    [Fact]
    public void Validate_AcceptsCompleteBank() => Assert.Empty(new CompanyBank { Code = "BN", Name = "Banco Nacional", Account = "100-01" }.Validate());
}
