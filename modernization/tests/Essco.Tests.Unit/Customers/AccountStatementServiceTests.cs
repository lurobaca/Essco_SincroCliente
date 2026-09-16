using Essco.Application.Customers;
using Essco.Domain.Customers;
namespace Essco.Tests.Unit.Customers;
public sealed class AccountStatementServiceTests
{
 [Fact]public async Task RejectsReversedRange()=>await Assert.ThrowsAsync<ArgumentException>(async()=>await new AccountStatementService(new Repository()).GetAsync(new(2026,2,1),new(2026,1,1),AccountStatementStatus.All,CancellationToken.None));
 [Fact]public async Task RejectsRangeOverOneYear()=>await Assert.ThrowsAsync<ArgumentException>(async()=>await new AccountStatementService(new Repository()).GetAsync(new(2025,1,1),new(2026,2,1),AccountStatementStatus.All,CancellationToken.None));
 private sealed class Repository:IAccountStatementRepository{public ValueTask<IReadOnlyCollection<AccountStatementEntry>> GetAsync(DateOnly from,DateOnly to,AccountStatementStatus status,CancellationToken token)=>ValueTask.FromResult<IReadOnlyCollection<AccountStatementEntry>>([]);}
}
