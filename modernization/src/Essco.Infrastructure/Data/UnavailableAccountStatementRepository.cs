using Essco.Application.Customers;
using Essco.Domain.Customers;
namespace Essco.Infrastructure.Data;
public sealed class UnavailableAccountStatementRepository:IAccountStatementRepository
{public ValueTask<IReadOnlyCollection<AccountStatementEntry>> GetAsync(DateOnly from,DateOnly to,AccountStatementStatus status,CancellationToken token)=>ValueTask.FromResult<IReadOnlyCollection<AccountStatementEntry>>([]);}
