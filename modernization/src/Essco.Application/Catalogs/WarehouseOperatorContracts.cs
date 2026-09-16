using Essco.Domain.Catalogs;

namespace Essco.Application.Catalogs;

public interface IWarehouseOperatorRepository
{
    ValueTask<IReadOnlyCollection<WarehouseOperator>> ListAsync(CancellationToken token);
    ValueTask<bool> SaveAsync(WarehouseOperator warehouseOperator, bool isNew, string? newPassword, CancellationToken token);
    ValueTask<bool> DeleteAsync(string code, CancellationToken token);
}

public sealed class WarehouseOperatorService(IWarehouseOperatorRepository repository)
{
    public ValueTask<IReadOnlyCollection<WarehouseOperator>> ListAsync(CancellationToken token) => repository.ListAsync(token);

    public async ValueTask<(bool Succeeded, IReadOnlyCollection<string> Errors)> SaveAsync(WarehouseOperator warehouseOperator, bool isNew, string? newPassword, CancellationToken token)
    {
        var errors = warehouseOperator.Validate().ToList();
        if (isNew && string.IsNullOrWhiteSpace(newPassword)) errors.Add("La clave es obligatoria para un bodeguero nuevo.");
        if (!string.IsNullOrEmpty(newPassword) && newPassword.Length > 200) errors.Add("La clave no puede superar 200 caracteres.");
        if (errors.Count > 0) return (false, errors);
        return await repository.SaveAsync(warehouseOperator, isNew, newPassword, token)
            ? (true, [])
            : (false, [isNew ? "Ya existe un bodeguero con ese código." : "El bodeguero ya no existe."]);
    }

    public ValueTask<bool> DeleteAsync(string code, CancellationToken token) => repository.DeleteAsync(code, token);
}
