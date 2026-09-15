namespace Essco.Domain.Security;

public enum CredentialFormat
{
    LegacyPlainText,
    Pbkdf2Sha512
}

public sealed class UserAccount
{
    public UserAccount(
        int id,
        string username,
        string displayName,
        string role,
        string credential,
        CredentialFormat credentialFormat,
        bool mustChangePassword,
        int failedAccessCount = 0,
        DateTimeOffset? lockedUntil = null)
    {
        if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id));
        if (string.IsNullOrWhiteSpace(username)) throw new ArgumentException("El usuario es obligatorio.", nameof(username));
        if (string.IsNullOrWhiteSpace(role)) throw new ArgumentException("El puesto o rol es obligatorio.", nameof(role));
        ArgumentNullException.ThrowIfNull(credential);

        Id = id;
        Username = username.Trim();
        NormalizedUsername = NormalizeUsername(username);
        DisplayName = displayName.Trim();
        Role = role.Trim();
        Credential = credential;
        CredentialFormat = credentialFormat;
        MustChangePassword = mustChangePassword;
        FailedAccessCount = failedAccessCount;
        LockedUntil = lockedUntil;
    }

    public int Id { get; }
    public string Username { get; }
    public string NormalizedUsername { get; }
    public string DisplayName { get; }
    public string Role { get; }
    public string Credential { get; private set; }
    public CredentialFormat CredentialFormat { get; private set; }
    public bool MustChangePassword { get; private set; }
    public int FailedAccessCount { get; private set; }
    public DateTimeOffset? LockedUntil { get; private set; }

    public bool IsLocked(DateTimeOffset now) => LockedUntil is not null && LockedUntil > now;

    public void RecordFailedAccess(DateTimeOffset now, int maximumAttempts, TimeSpan lockDuration)
    {
        if (maximumAttempts < 1) throw new ArgumentOutOfRangeException(nameof(maximumAttempts));
        if (lockDuration <= TimeSpan.Zero) throw new ArgumentOutOfRangeException(nameof(lockDuration));

        FailedAccessCount++;
        if (FailedAccessCount >= maximumAttempts)
        {
            LockedUntil = now.Add(lockDuration);
            FailedAccessCount = 0;
        }
    }

    public void RecordSuccessfulAccess()
    {
        FailedAccessCount = 0;
        LockedUntil = null;
    }

    public void UpgradeCredential(string passwordHash)
    {
        if (string.IsNullOrWhiteSpace(passwordHash)) throw new ArgumentException("El hash es obligatorio.", nameof(passwordHash));
        Credential = passwordHash;
        CredentialFormat = CredentialFormat.Pbkdf2Sha512;
        MustChangePassword = true;
    }

    public static string NormalizeUsername(string username) => username.Trim().ToUpperInvariant();
}
