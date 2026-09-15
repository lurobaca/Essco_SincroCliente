using Essco.Application.Security;
using Essco.Domain.Security;

namespace Essco.Infrastructure.Data;

public sealed class UnavailableUserAccountRepository : IUserAccountRepository
{
    public ValueTask<UserAccount?> FindByNormalizedUsernameAsync(string normalizedUsername, CancellationToken cancellationToken) =>
        ValueTask.FromResult<UserAccount?>(null);

    public ValueTask SaveAuthenticationStateAsync(UserAccount account, CancellationToken cancellationToken) =>
        ValueTask.FromException(new InvalidOperationException("El repositorio de usuarios no está configurado."));
}
