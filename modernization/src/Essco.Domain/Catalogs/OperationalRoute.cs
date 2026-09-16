namespace Essco.Domain.Catalogs;

public sealed record OperationalRoute
{
    public int Id { get; init; }
    public required string Description { get; init; }
    public IReadOnlyCollection<string> Validate() => string.IsNullOrWhiteSpace(Description) ? ["La descripción es obligatoria."] : Description.Trim().Length > 150 ? ["La descripción no puede superar 150 caracteres."] : [];
}
