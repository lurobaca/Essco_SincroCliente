using Essco.Domain.Catalogs;
using Essco.Application.Catalogs;

namespace Essco.Tests.Unit.Catalogs;

public sealed class WarehouseOperatorTests
{
    [Fact]
    public void Validate_RejectsInvalidSectors() => Assert.Contains(new WarehouseOperator { Code = "1", Name = "Ana", Phone = "", LoadSequence = "", ReturnSequence = "", Email = "", FtpPath = "", Position = "Bodeguero", Identification = "", Username = "ana", Sectors = [0, 21] }.Validate(), x => x.Contains("sectores", StringComparison.OrdinalIgnoreCase));

    [Fact]
    public void Validate_AcceptsCompatibleOperator() => Assert.Empty(new WarehouseOperator { Code = "1", Name = "Ana", Phone = "", LoadSequence = "1", ReturnSequence = "1", Email = "ana@example.com", FtpPath = "", Position = "Bodeguero", Identification = "1", Username = "ana", Sectors = [1, 5, 20] }.Validate());

    [Fact]
    public async Task Create_RequiresPassword()
    {
        var repository = new FakeRepository();
        var result = await new WarehouseOperatorService(repository).SaveAsync(ValidOperator(), true, null, default);
        Assert.False(result.Succeeded);
        Assert.False(repository.Saved);
    }

    [Fact]
    public async Task Update_PreservesPasswordWhenBlank()
    {
        var repository = new FakeRepository();
        var result = await new WarehouseOperatorService(repository).SaveAsync(ValidOperator(), false, "", default);
        Assert.True(result.Succeeded);
        Assert.True(repository.Saved);
        Assert.Equal("", repository.Password);
    }

    private static WarehouseOperator ValidOperator() => new() { Code = "1", Name = "Ana", Phone = "", LoadSequence = "1", ReturnSequence = "1", Email = "ana@example.com", FtpPath = "", Position = "Bodeguero", Identification = "1", Username = "ana", Sectors = [1] };

    private sealed class FakeRepository : IWarehouseOperatorRepository
    {
        public bool Saved { get; private set; }
        public string? Password { get; private set; }
        public ValueTask<IReadOnlyCollection<WarehouseOperator>> ListAsync(CancellationToken token) => ValueTask.FromResult<IReadOnlyCollection<WarehouseOperator>>([]);
        public ValueTask<bool> SaveAsync(WarehouseOperator warehouseOperator, bool isNew, string? newPassword, CancellationToken token) { Saved = true; Password = newPassword; return ValueTask.FromResult(true); }
        public ValueTask<bool> DeleteAsync(string code, CancellationToken token) => ValueTask.FromResult(true);
    }
}
