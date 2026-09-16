using Essco.Domain.Customers;
namespace Essco.Application.Customers;
public interface IAccountStatementRepository
{
    ValueTask<IReadOnlyCollection<AccountStatementEntry>> GetAsync(DateOnly from,DateOnly to,AccountStatementStatus status,CancellationToken cancellationToken);
}
public sealed class AccountStatementService(IAccountStatementRepository repository)
{
    public ValueTask<IReadOnlyCollection<AccountStatementEntry>> GetAsync(DateOnly from,DateOnly to,AccountStatementStatus status,CancellationToken token)
    {
        if(from>to)throw new ArgumentException("La fecha inicial no puede ser posterior a la final.");
        if(to.DayNumber-from.DayNumber>366)throw new ArgumentException("El rango no puede superar 366 días.");
        return repository.GetAsync(from,to,status,token);
    }
}
