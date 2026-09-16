using Essco.Domain.Catalogs;

namespace Essco.Tests.Unit.Catalogs;

public sealed class PickingWarehouseTests
{
    [Fact]
    public void Validate_RejectsIncompleteGeometry()
    {
        var errors = new PickingWarehouse { Id = 0, Name = "", Location = "", Racks = 0, Columns = 0 }.Validate();
        Assert.Equal(5, errors.Count);
    }

    [Fact]
    public void Validate_AcceptsCompleteWarehouse() => Assert.Empty(new PickingWarehouse { Id = 1, Name = "Principal", Location = "San José", Racks = 10, Columns = 8 }.Validate());
}
