using Essco.Application.Security;
using Essco.Domain.Security;

namespace Essco.Tests.Unit.Security;

public sealed class AuthenticationServiceTests
{
    [Fact]
    public async Task AuthenticateAsync_UpgradesSuccessfulLegacyCredential()
    {
        var account = new UserAccount(7, "operador", "Operador", "Ventas", "legacy-value", CredentialFormat.LegacyPlainText, false);
        var repository = new FakeRepository(account);
        var service = new AuthenticationService(repository, new FakePasswordService(), TimeProvider.System, AuthenticationPolicy.Default);

        var result = await service.AuthenticateAsync(new("operador", "correcta"), CancellationToken.None);

        Assert.Equal(AuthenticationStatus.Succeeded, result.Status);
        Assert.Equal(CredentialFormat.Pbkdf2Sha512, account.CredentialFormat);
        Assert.True(result.MustChangePassword);
        Assert.Equal(1, repository.SaveCount);
    }

    [Fact]
    public async Task AuthenticateAsync_LocksAfterRepeatedFailures()
    {
        var account = new UserAccount(7, "operador", "Operador", "Ventas", "legacy-value", CredentialFormat.LegacyPlainText, false);
        var repository = new FakeRepository(account);
        var service = new AuthenticationService(repository, new FakePasswordService(), TimeProvider.System, new(2, TimeSpan.FromMinutes(15)));

        await service.AuthenticateAsync(new("operador", "incorrecta"), CancellationToken.None);
        var result = await service.AuthenticateAsync(new("operador", "incorrecta"), CancellationToken.None);

        Assert.Equal(AuthenticationStatus.LockedOut, result.Status);
        Assert.NotNull(result.LockedUntil);
    }

    private sealed class FakeRepository(UserAccount account) : IUserAccountRepository
    {
        public int SaveCount { get; private set; }

        public ValueTask<UserAccount?> FindByNormalizedUsernameAsync(string normalizedUsername, CancellationToken cancellationToken) =>
            ValueTask.FromResult<UserAccount?>(normalizedUsername == account.NormalizedUsername ? account : null);

        public ValueTask SaveAuthenticationStateAsync(UserAccount savedAccount, CancellationToken cancellationToken)
        {
            Assert.Same(account, savedAccount);
            SaveCount++;
            return ValueTask.CompletedTask;
        }
    }

    private sealed class FakePasswordService : IPasswordService
    {
        public string Hash(string password) => "new-hash";
        public bool VerifyHash(string password, string encodedHash) => password == "correcta";
        public bool VerifyLegacy(string password, string legacyCredential) => password == "correcta";
    }
}
