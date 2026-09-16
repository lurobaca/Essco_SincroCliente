using Essco.Domain.Catalogs;
namespace Essco.Tests.Unit.Catalogs;
public sealed class DriverTests
{
 [Fact]public void Validate_RejectsUnknownType()=>Assert.Contains((Valid() with{Type="OTRO"}).Validate(),x=>x.Contains("tipo",StringComparison.OrdinalIgnoreCase));
 [Theory][InlineData("CHOFER")][InlineData("AYUDANTE")]public void Validate_AcceptsKnownTypes(string type)=>Assert.Empty((Valid() with{Type=type}).Validate());
 private static Driver Valid()=>new(){Code="1",Identification="1",Name="Ana",Phone="",OrderSequence="1",PaymentSequence="1",DepositSequence="1",ExpenseSequence="1",NoVisitSequence="1",Email="",FtpPath="",Type="CHOFER",ReturnSequence="1"};
}
