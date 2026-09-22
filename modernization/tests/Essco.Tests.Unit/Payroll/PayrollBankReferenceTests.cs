using Essco.Application.Payroll;
namespace Essco.Tests.Unit.Payroll;

public sealed class PayrollBankReferenceTests
{
    [Fact]
    public void Credit_reference_uses_employee_id_and_company_convenio_collaborator()
    {
        var batch = new PayrollBankBatch(new(1, "COMPANY", "Empresa", "ACCOUNT", "Pago", new(2026, 1, 1)),
            [new("CREDIT", 10, "Persona", "EMPLOYEE", "COLLAB")]);
        var line = PayrollBankFileService.Render(batch).Split("\r\n", StringSplitOptions.RemoveEmptyEntries)[2];
        Assert.EndsWith("|EMPLOYEE|EMPLOYEE.1.COMPANY1COLLAB||", line);
    }
    [Fact]
    public async Task Missing_employee_identification_blocks_generation()
    {
        var batch = new PayrollBankBatch(new(1, "COMPANY", "Empresa", "ACCOUNT", "Pago", new(2026, 1, 1)),
            [new("CREDIT", 10, "Persona", "", "COLLAB")]);
        var result = await new PayrollBankFileService(new Repository(batch)).GenerateAsync(1, new(2026, 1, 1), default);
        Assert.False(result.Succeeded);
        Assert.Empty(result.Content);
    }
    private sealed class Repository(PayrollBankBatch batch) : IPayrollBankRepository
    {
        public ValueTask<PayrollBankBatch?> GetAsync(int number, DateOnly date, CancellationToken token) => ValueTask.FromResult<PayrollBankBatch?>(batch);
    }
}
