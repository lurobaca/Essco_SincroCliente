using Essco.Application.Treasury; using Essco.Domain.Treasury;
namespace Essco.Infrastructure.Data;
public sealed class UnavailableIncomingReceiptRepository:IIncomingReceiptRepository
{ public ValueTask<IReadOnlyCollection<IncomingReceipt>> ListAsync(IncomingReceiptFilter f,CancellationToken t)=>ValueTask.FromResult<IReadOnlyCollection<IncomingReceipt>>([]); public ValueTask<IncomingReceipt?> GetAsync(int id,CancellationToken t)=>ValueTask.FromResult<IncomingReceipt?>(null); }
