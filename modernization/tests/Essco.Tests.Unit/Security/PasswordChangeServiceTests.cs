using Essco.Application.Security;
using Essco.Domain.Security;

namespace Essco.Tests.Unit.Security;

public sealed class PasswordChangeServiceTests
{
    [Fact]
    public async Task ChangeAsync_StoresNewHashAndClearsRequiredFlag()
    {
        var account = new UserAccount(3, "usuario", "Usuario", "Ventas", "old-hash", CredentialFormat.Pbkdf2Sha512, true);
        var repository = new Repository(account);
        var service = new PasswordChangeService(repository, new Passwords(), PasswordPolicy.Default);

        var result = await service.ChangeAsync(3, "usuario", "actual", "NuevaClave2026", CancellationToken.None);

        Assert.True(result.Succeeded);
        Assert.False(account.MustChangePassword);
        Assert.Equal("hash:NuevaClave2026", account.Credential);
        Assert.True(repository.Saved);
    }

    [Theory]
    [InlineData("corta1A")]
    [InlineData("SINMINUSCULAS2026")]
    [InlineData("sinmayusculas2026")]
    [InlineData("SinNumerosLargos")]
    public async Task ChangeAsync_RejectsWeakPasswords(string password)
    {
        var account = new UserAccount(3, "usuario", "Usuario", "Ventas", "old-hash", CredentialFormat.Pbkdf2Sha512, true);
        var service = new PasswordChangeService(new Repository(account), new Passwords(), PasswordPolicy.Default);

        var result = await service.ChangeAsync(3, "usuario", "actual", password, CancellationToken.None);

        Assert.False(result.Succeeded);
        Assert.NotEmpty(result.Errors);
    }

    private sealed class Repository(UserAccount account) : IUserAccountRepository
    {
        public bool Saved { get; private set; }
        public ValueTask<UserAccount?> FindByNormalizedUsernameAsync(string normalizedUsername, CancellationToken cancellationToken) =>
            ValueTask.FromResult<UserAccount?>(account);
        public ValueTask SaveAuthenticationStateAsync(UserAccount saved, CancellationToken cancellationToken)
        {
            Saved = true;
            return ValueTask.CompletedTask;
        }
    }

    private sealed class Passwords : IPasswordService
    {
        public string Hash(string password) => $"hash:{password}";
        public bool VerifyHash(string password, string encodedHash) => password == "actual";
        public bool VerifyLegacy(string password, string legacyCredential) => password == legacyCredential;
    }
}
