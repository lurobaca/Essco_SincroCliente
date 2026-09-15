using Essco.Infrastructure.Security;

namespace Essco.Tests.Integration.Security;

public sealed class Pbkdf2PasswordServiceTests
{
    [Fact]
    public void HashAndVerify_RoundTripsWithoutStoringPassword()
    {
        var service = new Pbkdf2PasswordService();

        var hash = service.Hash("una-clave-distinta-por-prueba");

        Assert.StartsWith("$ESSCO$PBKDF2-SHA512$", hash, StringComparison.Ordinal);
        Assert.DoesNotContain("una-clave-distinta-por-prueba", hash, StringComparison.Ordinal);
        Assert.True(service.VerifyHash("una-clave-distinta-por-prueba", hash));
        Assert.False(service.VerifyHash("incorrecta", hash));
    }

    [Fact]
    public void VerifyHash_RejectsMalformedValues()
    {
        var service = new Pbkdf2PasswordService();

        Assert.False(service.VerifyHash("clave", "texto-plano"));
        Assert.False(service.VerifyHash("clave", "$ESSCO$PBKDF2-SHA512$1$bad$bad"));
    }
}
