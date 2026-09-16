using Essco.Application.Companies;

namespace Essco.Infrastructure.Data;

public sealed class UnavailableGeographyRepository : IGeographyRepository
{
    private static readonly IReadOnlyCollection<LocationOption> Empty = [];
    public ValueTask<IReadOnlyCollection<LocationOption>> GetProvincesAsync(CancellationToken cancellationToken) => ValueTask.FromResult(Empty);
    public ValueTask<IReadOnlyCollection<LocationOption>> GetCantonsAsync(int provinceId, CancellationToken cancellationToken) => ValueTask.FromResult(Empty);
    public ValueTask<IReadOnlyCollection<LocationOption>> GetDistrictsAsync(int provinceId, int cantonId, CancellationToken cancellationToken) => ValueTask.FromResult(Empty);
    public ValueTask<IReadOnlyCollection<LocationOption>> GetNeighborhoodsAsync(int provinceId, int cantonId, int districtId, CancellationToken cancellationToken) => ValueTask.FromResult(Empty);
}
