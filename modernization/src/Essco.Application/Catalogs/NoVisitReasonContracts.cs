using Essco.Domain.Catalogs;

namespace Essco.Application.Catalogs;

public interface INoVisitReasonRepository
{
    ValueTask<IReadOnlyCollection<NoVisitReason>> ListAsync(CancellationToken token);
    ValueTask<int> SaveAsync(NoVisitReason reason, CancellationToken token);
    ValueTask<bool> DeleteAsync(int code, CancellationToken token);
}

public sealed class NoVisitReasonService(INoVisitReasonRepository repository)
{
    public ValueTask<IReadOnlyCollection<NoVisitReason>> ListAsync(CancellationToken token) => repository.ListAsync(token);

    public async ValueTask<(bool Succeeded, int Code, IReadOnlyCollection<string> Errors)> SaveAsync(NoVisitReason reason, CancellationToken token)
    {
        var errors = reason.Validate();
        return errors.Count > 0
            ? (false, reason.Code, errors)
            : (true, await repository.SaveAsync(reason, token), []);
    }

    public ValueTask<bool> DeleteAsync(int code, CancellationToken token) => repository.DeleteAsync(code, token);
}
