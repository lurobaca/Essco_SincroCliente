using Essco.Domain.Liquidations;
namespace Essco.Application.Liquidations;
public sealed record LiquidationWriteResult(bool Succeeded,int Consecutive=0,string? Error=null);
public interface ILiquidationRepository
{
    ValueTask<IReadOnlyCollection<Liquidation>> ListAsync(LiquidationFilter filter,CancellationToken token);
    ValueTask<LiquidationWriteResult> CreateAsync(Liquidation value,CancellationToken token);
    ValueTask<LiquidationWriteResult> UpdateAsync(Liquidation value,CancellationToken token);
    ValueTask<bool> AnnulAsync(LiquidationKind kind,int consecutive,string type,CancellationToken token);
    ValueTask<LiquidationSummary?> GetSummaryAsync(LiquidationKind kind,int consecutive,CancellationToken token);
    ValueTask<bool> RecalculateAsync(LiquidationKind kind,int consecutive,CancellationToken token);
}
public sealed class LiquidationService(ILiquidationRepository repository)
{
    public ValueTask<IReadOnlyCollection<Liquidation>> ListAsync(LiquidationFilter filter,CancellationToken token)=>repository.ListAsync(filter,token);
    public async ValueTask<LiquidationWriteResult> SaveAsync(Liquidation value,bool isNew,CancellationToken token)
    { value=value with{Type=value.Type.Trim().ToUpperInvariant()};var errors=value.Validate();if(errors.Count>0)return new(false,value.Consecutive,string.Join(" ",errors));return isNew?await repository.CreateAsync(value,token):await repository.UpdateAsync(value,token); }
    public ValueTask<bool> AnnulAsync(LiquidationKind kind,int consecutive,string type,CancellationToken token)=>repository.AnnulAsync(kind,consecutive,type.Trim().ToUpperInvariant(),token);
    public ValueTask<LiquidationSummary?> GetSummaryAsync(LiquidationKind kind,int consecutive,CancellationToken token)=>repository.GetSummaryAsync(kind,consecutive,token);
    public ValueTask<bool> RecalculateAsync(LiquidationKind kind,int consecutive,CancellationToken token)=>repository.RecalculateAsync(kind,consecutive,token);
}
