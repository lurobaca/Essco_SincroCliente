using Essco.Domain.Catalogs;
namespace Essco.Tests.Unit.Catalogs;

public sealed class OperationalRouteTests { [Fact] public void Validate_RequiresDescription() => Assert.Contains(new OperationalRoute { Description = "" }.Validate(), x => x.Contains("obligatoria", StringComparison.Ordinal)); [Fact] public void Validate_AcceptsDescription() => Assert.Empty(new OperationalRoute { Description = "Ruta 1" }.Validate()); }
