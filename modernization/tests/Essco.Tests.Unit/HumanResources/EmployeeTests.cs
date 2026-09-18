using Essco.Application.HumanResources;
namespace Essco.Tests.Unit.HumanResources;
public sealed class EmployeeTests
{
 [Fact]public void Accepts_legacy_position_and_category()=>Assert.Empty(Valid().Validate());
 [Fact]public void Rejects_values_outside_legacy_catalogs(){var errors=(Valid()with{Position="Inventado",Category="Otra"}).Validate();Assert.Contains(errors,x=>x.Contains("puesto",StringComparison.OrdinalIgnoreCase));Assert.Contains(errors,x=>x.Contains("categoría",StringComparison.OrdinalIgnoreCase));}
 private static EmployeeInput Valid()=>new("1","E1","Empleado","TI",100,new(2020,1,1),true,"","","","","","","","Administrativo",0,0,0);
}
