using Essco.Domain.Security;

namespace Essco.Application.Security;

public interface IUserAccountRepository
{
    ValueTask<UserAccount?> FindByNormalizedUsernameAsync(string normalizedUsername, CancellationToken cancellationToken);
    ValueTask SaveAuthenticationStateAsync(UserAccount account, CancellationToken cancellationToken);
}

public interface IPasswordService
{
    string Hash(string password);
    bool VerifyHash(string password, string encodedHash);
    bool VerifyLegacy(string password, string legacyCredential);
}

public sealed record AuthenticationRequest(string Username, string Password);

public enum AuthenticationStatus
{
    Succeeded,
    InvalidCredentials,
    LockedOut
}

public sealed record AuthenticationResult(
    AuthenticationStatus Status,
    int? UserId = null,
    string? Username = null,
    string? DisplayName = null,
    string? Role = null,
    bool MustChangePassword = false,
    DateTimeOffset? LockedUntil = null);
