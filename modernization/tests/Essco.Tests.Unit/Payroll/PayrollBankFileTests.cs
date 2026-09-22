using System.Text;
using Essco.Application.Payroll;
namespace Essco.Tests.Unit.Payroll;

public sealed class PayrollBankFileTests
{
    [Fact] public void Renders_legacy_hd_and_da_records() { var batch = new PayrollBankBatch(new(7, "3102688789", "ESSCO", "161010001", "Pago quincenal", new(2026, 9, 16)), [new("0000798709", 152978.03m, "Ana | Mora", "205240893", "1420324")]); var text = PayrollBankFileService.Render(batch); var lines = text.Split("\r\n", StringSplitOptions.RemoveEmptyEntries); Assert.Equal("HD|3102688789.1|20260916|161010001|CRC|152978.03|2|1|1", lines[0]); Assert.StartsWith("DA|161010001||||152978.03||||544||ESSCO", lines[1]); Assert.Contains("DA|0000798709||||152978.03||||545||Ana  Mora", lines[2]); Assert.EndsWith("|205240893.1.310268878911420324||", lines[2]); }
    [Fact] public async Task Rejects_missing_employee_bank_data() { var batch = new PayrollBankBatch(new(7, "3102688789", "ESSCO", "161", "Pago", new(2026, 9, 16)), [new("", 10, "Ana", "1", "")]); var result = await new PayrollBankFileService(new Repo(batch)).GenerateAsync(7, new(2026, 9, 16), default); Assert.False(result.Succeeded); Assert.Empty(result.Content); }
    private sealed class Repo(PayrollBankBatch batch) : IPayrollBankRepository { public ValueTask<PayrollBankBatch?> GetAsync(int n, DateOnly d, CancellationToken t) => ValueTask.FromResult<PayrollBankBatch?>(batch); }
}
