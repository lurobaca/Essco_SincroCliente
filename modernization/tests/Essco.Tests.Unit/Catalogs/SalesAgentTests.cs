using Essco.Domain.Catalogs;

namespace Essco.Tests.Unit.Catalogs;

public sealed class SalesAgentTests
{
    [Fact]
    public void Validate_RejectsReservedCode() => Assert.Contains((Valid() with { Code = "3" }).Validate(), x => x.Contains("reservado", StringComparison.OrdinalIgnoreCase));
    [Fact]
    public void Validate_RejectsUnknownPosition() => Assert.Contains((Valid() with { Position = "OTRO" }).Validate(), x => x.Contains("puesto", StringComparison.OrdinalIgnoreCase));
    [Fact]
    public void Validate_AcceptsKnownPosition() => Assert.Empty(Valid().Validate());

    private static SalesAgent Valid() => new() { Code = "10", Identification = "1", Name = "Ana", Phone = "", OrderSequence = "1", PaymentSequence = "1", DepositSequence = "1", ExpenseSequence = "1", NoVisitSequence = "1", Email = "ana@example.com", FtpPath = "", Group = "A", ReturnSequence = "1", NewCustomerSequence = "1", Position = "AGENTE" };
}
