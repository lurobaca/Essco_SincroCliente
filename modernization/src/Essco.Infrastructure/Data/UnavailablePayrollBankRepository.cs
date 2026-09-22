using Essco.Application.Payroll;
namespace Essco.Infrastructure.Data; public sealed class UnavailablePayrollBankRepository : IPayrollBankRepository { public ValueTask<PayrollBankBatch?> GetAsync(int n, DateOnly d, CancellationToken t) => ValueTask.FromResult<PayrollBankBatch?>(null); }
