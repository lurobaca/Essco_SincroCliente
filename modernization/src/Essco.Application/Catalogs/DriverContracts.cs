using Essco.Domain.Catalogs;

namespace Essco.Application.Catalogs;

public interface IDriverRepository
{
    ValueTask<IReadOnlyCollection<Driver>> ListAsync(string? type, CancellationToken token);
    ValueTask<bool> SaveAsync(Driver driver, bool isNew, CancellationToken token);
    ValueTask<bool> DeleteAsync(string code, CancellationToken token);
}

public sealed class DriverService(IDriverRepository repository)
{
    public ValueTask<IReadOnlyCollection<Driver>> ListAsync(string? type, CancellationToken token) => repository.ListAsync(Normalize(type), token);
    public async ValueTask<(bool Succeeded, IReadOnlyCollection<string> Errors)> SaveAsync(Driver driver, bool isNew, CancellationToken token)
    {
        driver = driver with { Type = driver.Type.Trim().ToUpperInvariant() };
        var errors = driver.Validate();
        if (errors.Count > 0) return (false, errors);
        return await repository.SaveAsync(driver, isNew, token) ? (true, []) : (false, [isNew ? "Ya existe un chofer con ese código." : "El chofer ya no existe."]);
    }
    public ValueTask<bool> DeleteAsync(string code, CancellationToken token) => repository.DeleteAsync(code, token);
    private static string? Normalize(string? type) { var value = type?.Trim().ToUpperInvariant(); return value is "CHOFER" or "AYUDANTE" ? value : null; }
}
