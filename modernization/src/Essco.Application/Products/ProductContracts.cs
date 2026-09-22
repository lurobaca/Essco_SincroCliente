using Essco.Domain.Products;

namespace Essco.Application.Products;

public interface IProductRepository
{
    ValueTask<IReadOnlyCollection<Product>> ListAsync(ProductFilter filter, CancellationToken token);
    ValueTask<IReadOnlyCollection<AutomaticDiscount>> ListDiscountsAsync(CancellationToken token);
    ValueTask<bool> SaveDiscountAsync(AutomaticDiscount value, bool isNew, CancellationToken token);
    ValueTask<bool> DeleteDiscountAsync(string productCode, CancellationToken token);
    ValueTask<IReadOnlyCollection<PriceList>> ListPriceListsAsync(CancellationToken token);
    ValueTask<int> SavePriceListAsync(PriceList value, bool isNew, CancellationToken token);
    ValueTask<bool> SetPriceListInactiveAsync(int id, bool inactive, CancellationToken token);
}

/// <summary>Coordina las consultas y el mantenimiento del catálogo de productos.</summary>
public sealed class ProductService(IProductRepository repository)
{
    public ValueTask<IReadOnlyCollection<Product>> ListAsync(ProductFilter filter, CancellationToken token) =>
        repository.ListAsync(filter, token);

    public ValueTask<IReadOnlyCollection<AutomaticDiscount>> ListDiscountsAsync(CancellationToken token) =>
        repository.ListDiscountsAsync(token);

    /// <summary>Valida y guarda un descuento automático.</summary>
    public async ValueTask<(bool Succeeded, IReadOnlyCollection<string> Errors)> SaveDiscountAsync(
        AutomaticDiscount discount,
        bool isNew,
        CancellationToken token)
    {
        var errors = discount.Validate();
        if (errors.Count > 0)
        {
            return (false, errors);
        }

        var saved = await repository.SaveDiscountAsync(discount, isNew, token);
        return saved ? (true, []) : (false, ["El descuento ya existe o dejó de estar disponible."]);
    }

    public ValueTask<bool> DeleteDiscountAsync(string productCode, CancellationToken token) =>
        repository.DeleteDiscountAsync(productCode.Trim(), token);

    public ValueTask<IReadOnlyCollection<PriceList>> ListPriceListsAsync(CancellationToken token) =>
        repository.ListPriceListsAsync(token);

    /// <summary>Valida el nombre y guarda una lista de precios.</summary>
    public async ValueTask<(bool Succeeded, int Id, string? Error)> SavePriceListAsync(
        PriceList priceList,
        bool isNew,
        CancellationToken token)
    {
        if (string.IsNullOrWhiteSpace(priceList.Name))
        {
            return (false, priceList.Id, "El nombre es obligatorio.");
        }

        var id = await repository.SavePriceListAsync(priceList, isNew, token);
        return id > 0
            ? (true, id, null)
            : (false, priceList.Id, "La lista ya existe o no está disponible.");
    }

    public ValueTask<bool> SetPriceListInactiveAsync(int id, bool inactive, CancellationToken token) =>
        repository.SetPriceListInactiveAsync(id, inactive, token);
}
