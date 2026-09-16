using Essco.Application.HumanResources;

namespace Essco.Tests.Unit.HumanResources;

public sealed class EmployeeMovementTests
{
    [Fact]
    public async Task Deduction_requires_one_hundred_percent_distribution()
    {
        var repository = new Repository();
        var service = new EmployeeMovementService(repository);

        var result = await service.SaveDeductionAsync(new("1", "Judicial", 100, "", new(2026, 1, 1), 40, 40), default);

        Assert.False(result.Succeeded);
        Assert.Equal(0, repository.DeductionCalls);
    }

    [Fact]
    public async Task Loan_rejects_payment_greater_than_principal()
    {
        var repository = new Repository();
        var service = new EmployeeMovementService(repository);

        var result = await service.SaveLoanAsync(new("1", "Empleado", new(2026, 1, 1), 100, "Vale", "", 101), default);

        Assert.False(result.Succeeded);
        Assert.Equal(0, repository.LoanCalls);
    }

    [Fact]
    public async Task Valid_vacation_is_persisted()
    {
        var repository = new Repository();
        var service = new EmployeeMovementService(repository);

        var result = await service.SaveVacationAsync(new("1", new(2026, 1, 1), new(2026, 1, 2), 2, "Descanso"), default);

        Assert.True(result.Succeeded);
        Assert.Equal(17, result.Number);
    }

    private sealed class Repository : IEmployeeMovementRepository
    {
        public int DeductionCalls { get; private set; }
        public int LoanCalls { get; private set; }
        public ValueTask<int> SaveVacationAsync(VacationInput x, CancellationToken t) => ValueTask.FromResult(17);
        public ValueTask<int> SaveDisabilityAsync(DisabilityInput x, CancellationToken t) => ValueTask.FromResult(18);
        public ValueTask<int> SaveDeductionAsync(DeductionInput x, CancellationToken t) { DeductionCalls++; return ValueTask.FromResult(19); }
        public ValueTask<int> SaveLoanAsync(LoanInput x, CancellationToken t) { LoanCalls++; return ValueTask.FromResult(20); }
        public ValueTask<bool> AnnulAsync(string type, int number, CancellationToken t) => ValueTask.FromResult(true);
    }
}
