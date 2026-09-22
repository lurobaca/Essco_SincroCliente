using Essco.Application.Payroll;
using Essco.Application.Customers;
namespace Essco.Tests.Unit.Payroll;

public sealed class PayrollJournalValidationTests
{
    [Theory]
    [InlineData(100, 99)]
    [InlineData(-1, -1)]
    [InlineData(0, 0)]
    public async Task Worker_rejects_invalid_journal_without_calling_sap(int debit, int credit)
    {
        var gateway = new Gateway();
        var processor = new PayrollSapJobProcessor(new Repository(new(1, "", [new("100", debit, 0), new("200", 0, credit)])), gateway);
        var result = await processor.ProcessAsync(PayrollSapOperations.CreateJournal, "{\"Number\":1}", default);
        Assert.False(result.Succeeded);
        Assert.False(result.Retryable);
        Assert.False(gateway.Called);
    }
    private sealed class Repository(PayrollJournal journal) : IPayrollJournalRepository
    {
        public ValueTask<PayrollJournal?> GetAsync(int number, CancellationToken token) => ValueTask.FromResult<PayrollJournal?>(journal);
    }
    private sealed class Gateway : ISapPayrollGateway
    {
        public bool Called { get; private set; }
        public ValueTask<SapProcessingResult> CreateJournalAsync(PayrollJournal journal, CancellationToken token)
        { Called = true; return ValueTask.FromResult(new SapProcessingResult(true, "1", null, false)); }
    }
}
