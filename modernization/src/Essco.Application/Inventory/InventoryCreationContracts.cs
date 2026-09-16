namespace Essco.Application.Inventory;

public sealed record InventoryCreationResult(bool Succeeded, int? InventoryId = null, string? Error = null);

public interface IInventoryCreationRepository
{
    ValueTask<InventoryCreationResult> CreateAsync(string title, string comments, CancellationToken token);
}

public sealed class InventoryCreationService(IInventoryCreationRepository repository)
{
    public ValueTask<InventoryCreationResult> CreateAsync(string title, string comments, CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(title))
            return ValueTask.FromResult(new InventoryCreationResult(false, Error: "El título es obligatorio."));
        return repository.CreateAsync(title.Trim(), comments.Trim(), token);
    }
}
