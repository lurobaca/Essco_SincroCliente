using Essco.Application.Products;
using Essco.Domain.Products;

namespace Essco.Tests.Unit.Products;

public sealed class ProductServiceTests
{
    [Fact]
    public async Task Discount_rejects_invalid_percentage_and_dates()
    {
        var value = new AutomaticDiscount { ProductCode = "A", Description = "", Percentage = 101, From = new(2026, 2, 1), To = new(2026, 1, 1), MinimumQuantity = 1, AvailableQuantity = 1, Comments = "" };
        var result = await new ProductService(new Repository()).SaveDiscountAsync(value, true, default);
        Assert.False(result.Succeeded);
        Assert.Equal(2, result.Errors.Count);
    }

    [Fact]
    public async Task Price_list_requires_a_name()
    {
        var result = await new ProductService(new Repository()).SavePriceListAsync(new(0, " ", false), true, default);
        Assert.False(result.Succeeded);
        Assert.Equal("El nombre es obligatorio.", result.Error);
    }

    private sealed class Repository : IProductRepository
    {
        public ValueTask<IReadOnlyCollection<Product>> ListAsync(ProductFilter filter, CancellationToken token) => ValueTask.FromResult<IReadOnlyCollection<Product>>([]);
        public ValueTask<IReadOnlyCollection<AutomaticDiscount>> ListDiscountsAsync(CancellationToken token) => ValueTask.FromResult<IReadOnlyCollection<AutomaticDiscount>>([]);
        public ValueTask<bool> SaveDiscountAsync(AutomaticDiscount value, bool isNew, CancellationToken token) => ValueTask.FromResult(true);
        public ValueTask<bool> DeleteDiscountAsync(string productCode, CancellationToken token) => ValueTask.FromResult(true);
        public ValueTask<IReadOnlyCollection<PriceList>> ListPriceListsAsync(CancellationToken token) => ValueTask.FromResult<IReadOnlyCollection<PriceList>>([]);
        public ValueTask<int> SavePriceListAsync(PriceList value, bool isNew, CancellationToken token) => ValueTask.FromResult(1);
        public ValueTask<bool> SetPriceListInactiveAsync(int id, bool inactive, CancellationToken token) => ValueTask.FromResult(true);
    }
}
