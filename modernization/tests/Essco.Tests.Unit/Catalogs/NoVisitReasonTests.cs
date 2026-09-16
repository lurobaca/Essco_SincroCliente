using Essco.Domain.Catalogs;

namespace Essco.Tests.Unit.Catalogs;

public sealed class NoVisitReasonTests
{
    [Fact]
    public void Validate_RequiresReason() => Assert.Contains(new NoVisitReason { Reason = "" }.Validate(), x => x.Contains("obligatoria", StringComparison.Ordinal));

    [Fact]
    public void Validate_AcceptsReason() => Assert.Empty(new NoVisitReason { Reason = "Cliente cerrado" }.Validate());
}
