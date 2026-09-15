using Essco.Domain.Security;

namespace Essco.Tests.Unit.Security;

public sealed class UserAccountTests
{
    [Fact]
    public void RecordFailedAccess_LocksAfterConfiguredAttempts()
    {
        var now = DateTimeOffset.Parse("2026-09-15T12:00:00Z");
        var account = CreateAccount();

        account.RecordFailedAccess(now, 2, TimeSpan.FromMinutes(15));
        Assert.False(account.IsLocked(now));
        account.RecordFailedAccess(now, 2, TimeSpan.FromMinutes(15));

        Assert.True(account.IsLocked(now));
        Assert.Equal(now.AddMinutes(15), account.LockedUntil);
    }

    [Fact]
    public void UpgradeCredential_RemovesLegacyFormatAndRequiresChange()
    {
        var account = CreateAccount();

        account.UpgradeCredential("encoded-hash");

        Assert.Equal(CredentialFormat.Pbkdf2Sha512, account.CredentialFormat);
        Assert.True(account.MustChangePassword);
        Assert.Equal("encoded-hash", account.Credential);
    }

    private static UserAccount CreateAccount() => new(1, "usuario", "Usuario", "Operador", "legacy", CredentialFormat.LegacyPlainText, false);
}
