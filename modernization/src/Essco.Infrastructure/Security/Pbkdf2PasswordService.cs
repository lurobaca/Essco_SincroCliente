using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using Essco.Application.Security;

namespace Essco.Infrastructure.Security;

public sealed class Pbkdf2PasswordService : IPasswordService
{
    private const string Prefix = "$ESSCO$PBKDF2-SHA512";
    private const int Iterations = 210_000;
    private const int SaltSize = 16;
    private const int HashSize = 32;

    public string Hash(string password)
    {
        ArgumentException.ThrowIfNullOrEmpty(password);
        var salt = RandomNumberGenerator.GetBytes(SaltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, HashAlgorithmName.SHA512, HashSize);
        return string.Join('$', Prefix, Iterations.ToString(CultureInfo.InvariantCulture), Convert.ToBase64String(salt), Convert.ToBase64String(hash));
    }

    public bool VerifyHash(string password, string encodedHash)
    {
        if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(encodedHash)) return false;

        // Formato: $ESSCO$PBKDF2-SHA512$iteraciones$sal$hash.
        var parts = encodedHash.Split('$', StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length != 5 || parts[0] != "ESSCO" || parts[1] != "PBKDF2-SHA512") return false;
        if (!int.TryParse(parts[2], NumberStyles.None, CultureInfo.InvariantCulture, out var iterations) || iterations < 100_000) return false;

        try
        {
            var salt = Convert.FromBase64String(parts[3]);
            var expected = Convert.FromBase64String(parts[4]);
            var actual = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, HashAlgorithmName.SHA512, expected.Length);
            return CryptographicOperations.FixedTimeEquals(actual, expected);
        }
        catch (FormatException)
        {
            return false;
        }
    }

    public bool VerifyLegacy(string password, string legacyCredential)
    {
        if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(legacyCredential)) return false;
        var provided = SHA256.HashData(Encoding.UTF8.GetBytes(password));
        var expected = SHA256.HashData(Encoding.UTF8.GetBytes(legacyCredential));
        return CryptographicOperations.FixedTimeEquals(provided, expected);
    }
}
