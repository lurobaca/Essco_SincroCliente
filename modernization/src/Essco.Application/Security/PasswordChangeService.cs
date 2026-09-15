using Essco.Domain.Security;

namespace Essco.Application.Security;

public sealed class PasswordChangeService(
    IUserAccountRepository repository,
    IPasswordService passwordService,
    PasswordPolicy policy)
{
    public async ValueTask<PasswordChangeResult> ChangeAsync(
        int userId,
        string username,
        string currentPassword,
        string newPassword,
        CancellationToken cancellationToken)
    {
        var policyErrors = policy.Validate(newPassword);
        if (policyErrors.Count > 0) return new(false, policyErrors);

        var account = await repository.FindByNormalizedUsernameAsync(
            UserAccount.NormalizeUsername(username), cancellationToken);
        if (account is null || account.Id != userId)
            return new(false, ["No fue posible validar la cuenta."]);

        var currentIsValid = account.CredentialFormat switch
        {
            CredentialFormat.LegacyPlainText => passwordService.VerifyLegacy(currentPassword, account.Credential),
            CredentialFormat.Pbkdf2Sha512 => passwordService.VerifyHash(currentPassword, account.Credential),
            _ => false
        };
        if (!currentIsValid) return new(false, ["La contraseña actual no es válida."]);
        if (passwordService.VerifyLegacy(newPassword, currentPassword))
            return new(false, ["La contraseña nueva debe ser diferente de la actual."]);

        account.ChangePassword(passwordService.Hash(newPassword));
        await repository.SaveAuthenticationStateAsync(account, cancellationToken);
        return new(true, []);
    }
}

public sealed record PasswordChangeResult(bool Succeeded, IReadOnlyCollection<string> Errors);

public sealed record PasswordPolicy(int MinimumLength)
{
    public static PasswordPolicy Default { get; } = new(12);

    public IReadOnlyCollection<string> Validate(string password)
    {
        var errors = new List<string>();
        if (string.IsNullOrEmpty(password) || password.Length < MinimumLength)
            errors.Add($"La contraseña debe tener al menos {MinimumLength} caracteres.");
        if (password?.Any(char.IsUpper) != true) errors.Add("La contraseña debe contener una letra mayúscula.");
        if (password?.Any(char.IsLower) != true) errors.Add("La contraseña debe contener una letra minúscula.");
        if (password?.Any(char.IsDigit) != true) errors.Add("La contraseña debe contener un número.");
        return errors;
    }
}
