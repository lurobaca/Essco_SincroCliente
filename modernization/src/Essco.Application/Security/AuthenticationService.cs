using Essco.Domain.Security;

namespace Essco.Application.Security;

public sealed class AuthenticationService(
    IUserAccountRepository repository,
    IPasswordService passwordService,
    TimeProvider timeProvider,
    AuthenticationPolicy policy)
{
    public async ValueTask<AuthenticationResult> AuthenticateAsync(AuthenticationRequest request, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrEmpty(request.Password))
            return new(AuthenticationStatus.InvalidCredentials);

        var account = await repository.FindByNormalizedUsernameAsync(
            UserAccount.NormalizeUsername(request.Username), cancellationToken);

        // La respuesta indistinguible evita revelar si el usuario existe.
        if (account is null)
            return new(AuthenticationStatus.InvalidCredentials);

        var now = timeProvider.GetUtcNow();
        if (account.IsLocked(now))
            return new(AuthenticationStatus.LockedOut, LockedUntil: account.LockedUntil);

        var verified = account.CredentialFormat switch
        {
            CredentialFormat.LegacyPlainText => passwordService.VerifyLegacy(request.Password, account.Credential),
            CredentialFormat.Pbkdf2Sha512 => passwordService.VerifyHash(request.Password, account.Credential),
            _ => false
        };

        if (!verified)
        {
            account.RecordFailedAccess(now, policy.MaximumFailedAttempts, policy.LockDuration);
            await repository.SaveAuthenticationStateAsync(account, cancellationToken);
            return new(account.IsLocked(now) ? AuthenticationStatus.LockedOut : AuthenticationStatus.InvalidCredentials,
                LockedUntil: account.LockedUntil);
        }

        if (account.CredentialFormat == CredentialFormat.LegacyPlainText)
            account.UpgradeCredential(passwordService.Hash(request.Password));

        account.RecordSuccessfulAccess();
        await repository.SaveAuthenticationStateAsync(account, cancellationToken);

        return new(
            AuthenticationStatus.Succeeded,
            account.Id,
            account.Username,
            account.DisplayName,
            account.Role,
            account.MustChangePassword);
    }
}

public sealed record AuthenticationPolicy(int MaximumFailedAttempts, TimeSpan LockDuration)
{
    public static AuthenticationPolicy Default { get; } = new(5, TimeSpan.FromMinutes(15));
}
