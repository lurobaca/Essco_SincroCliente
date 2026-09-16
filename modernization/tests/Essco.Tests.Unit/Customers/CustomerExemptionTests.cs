using Essco.Domain.Customers;

namespace Essco.Tests.Unit.Customers;

public sealed class CustomerExemptionTests
{
    [Fact]
    public void Validate_AcceptsValidExemption() => Assert.Empty(Valid().Validate());
    [Fact]
    public void Validate_RejectsUnknownDocumentType() => Assert.Contains((Valid() with { DocumentType = "08" }).Validate(), x => x.Contains("tipo", StringComparison.OrdinalIgnoreCase));
    [Fact]
    public void Validate_RejectsExpiredBeforeIssue() => Assert.Contains((Valid() with { ExpiresOn = new(2025, 1, 1) }).Validate(), x => x.Contains("vencimiento", StringComparison.OrdinalIgnoreCase));
    private static CustomerExemption Valid() => new() { CustomerCode = "C1", DocumentType = "01", Number = "EX-1", Institution = "Hacienda", IssuedOn = new(2026, 1, 1), ExpiresOn = new(2026, 12, 31), PurchasePercent = 50 };
}
