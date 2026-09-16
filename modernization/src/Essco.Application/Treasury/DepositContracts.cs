using Essco.Domain.Treasury;

namespace Essco.Application.Treasury;

public sealed record DepositWriteResult(bool Succeeded, int Consecutive = 0, string? Error = null);

public interface IDepositRepository
{
    ValueTask<IReadOnlyCollection<string>> ListBanksAsync(CancellationToken token);
    ValueTask<IReadOnlyCollection<Deposit>> ListAsync(DepositFilter filter, CancellationToken token);
    ValueTask<DepositWriteResult> CreateAsync(Deposit deposit, CancellationToken token);
    ValueTask<DepositWriteResult> UpdateAsync(Deposit deposit, CancellationToken token);
    ValueTask<bool> AnnulAsync(int consecutive, CancellationToken token);
    ValueTask<bool> LinkLiquidationAsync(int consecutive, string liquidationNumber, string liquidationType, CancellationToken token);
    ValueTask<bool> MarkUploadedAsync(int consecutive, CancellationToken token);
}

public sealed class DepositService(IDepositRepository repository)
{
    public ValueTask<IReadOnlyCollection<string>> ListBanksAsync(CancellationToken token) => repository.ListBanksAsync(token);
    public ValueTask<IReadOnlyCollection<Deposit>> ListAsync(DepositFilter filter, CancellationToken token) => repository.ListAsync(filter, token);
    public async ValueTask<DepositWriteResult> SaveAsync(Deposit deposit, bool isNew, CancellationToken token)
    {
        deposit = deposit with { LiquidationType = deposit.LiquidationType.Trim().ToUpperInvariant() };
        var errors = deposit.Validate();
        if (errors.Count > 0) return new(false, deposit.Consecutive, string.Join(" ", errors));
        return isNew ? await repository.CreateAsync(deposit, token) : await repository.UpdateAsync(deposit, token);
    }
    public ValueTask<bool> AnnulAsync(int consecutive, CancellationToken token) => repository.AnnulAsync(consecutive, token);
    public ValueTask<bool> LinkLiquidationAsync(int consecutive, string liquidationNumber, string liquidationType, CancellationToken token) => repository.LinkLiquidationAsync(consecutive, liquidationNumber.Trim(), liquidationType.Trim().ToUpperInvariant(), token);
    public ValueTask<bool> MarkUploadedAsync(int consecutive, CancellationToken token) => repository.MarkUploadedAsync(consecutive, token);
}
