using Essco.Application.Liquidations;
using Essco.Domain.Liquidations;
namespace Essco.Tests.Unit.Liquidations;

public sealed class LiquidationValidationTests
{
    private static Liquidation Valid => new() { Kind = LiquidationKind.Agents, Date = new(2026, 1, 1), EmployeeCode = "1", Identification = "2", EmployeeName = "Name", From = new(2026, 1, 1), To = new(2026, 1, 2), ReceiptFrom = new(2026, 1, 1), ReceiptTo = new(2026, 1, 2), Notes = "", Type = "AGENTES", Route = "", AgentCodes = "", InvoiceReportCodes = "" };
    [Fact] public void Rejects_unknown_responsible_type() => Assert.NotEmpty((Valid with { Kind = (LiquidationKind)99 }).Validate());
    [Fact] public void Rejects_truncation_of_employee_code() => Assert.NotEmpty((Valid with { EmployeeCode = new string('X', 51) }).Validate());
    [Fact] public void Allows_maximum_field_lengths() => Assert.Empty((Valid with { EmployeeCode = new string('X', 50), Notes = new string('X', 1000) }).Validate());
    [Fact]
    public async Task Invalid_annulment_never_calls_repository()
    {
        var service = new LiquidationService(new UnusedRepository());
        Assert.False(await service.AnnulAsync((LiquidationKind)99, 1, "AGENTES", default));
        Assert.False(await service.AnnulAsync(LiquidationKind.Agents, 0, "AGENTES", default));
        Assert.False(await service.AnnulAsync(LiquidationKind.Agents, 1, null!, default));
    }
    [Fact]
    public async Task Null_type_returns_validation_error_instead_of_throwing()
    {
        var result = await new LiquidationService(new UnusedRepository()).SaveAsync(Valid with { Type = null! }, true, default);
        Assert.False(result.Succeeded);
    }
    private sealed class UnusedRepository : ILiquidationRepository
    {
        public ValueTask<IReadOnlyCollection<Liquidation>> ListAsync(LiquidationFilter filter, CancellationToken token) => throw new InvalidOperationException();
        public ValueTask<LiquidationWriteResult> CreateAsync(Liquidation value, CancellationToken token) => throw new InvalidOperationException();
        public ValueTask<LiquidationWriteResult> UpdateAsync(Liquidation value, CancellationToken token) => throw new InvalidOperationException();
        public ValueTask<bool> AnnulAsync(LiquidationKind kind, int id, string type, CancellationToken token) => throw new InvalidOperationException();
        public ValueTask<LiquidationSummary?> GetSummaryAsync(LiquidationKind kind, int id, CancellationToken token) => throw new InvalidOperationException();
        public ValueTask<bool> RecalculateAsync(LiquidationKind kind, int id, CancellationToken token) => throw new InvalidOperationException();
    }
}
