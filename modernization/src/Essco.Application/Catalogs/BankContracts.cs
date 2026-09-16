using Essco.Domain.Catalogs;

namespace Essco.Application.Catalogs;

public interface IBankRepository
{
    ValueTask<IReadOnlyCollection<CompanyBank>> ListAsync(CancellationToken token);
    ValueTask CreateAsync(CompanyBank bank, CancellationToken token);
    ValueTask<bool> DeleteAsync(string code, CancellationToken token);
}

public sealed class BankService(IBankRepository repository)
{
    public ValueTask<IReadOnlyCollection<CompanyBank>> ListAsync(CancellationToken token) => repository.ListAsync(token);

    public async ValueTask<(bool Succeeded, IReadOnlyCollection<string> Errors)> CreateAsync(CompanyBank bank, CancellationToken token)
    {
        var errors = bank.Validate();
        if (errors.Count > 0) return (false, errors);
        await repository.CreateAsync(bank, token);
        return (true, []);
    }

    public ValueTask<bool> DeleteAsync(string code, CancellationToken token) => repository.DeleteAsync(code, token);
}
