using Essco.Application.Catalogs;
using Essco.Domain.Catalogs;
namespace Essco.Infrastructure.Data;
public sealed class UnavailableDriverRepository:IDriverRepository
{
    public ValueTask<IReadOnlyCollection<Driver>> ListAsync(string? type,CancellationToken token)=>ValueTask.FromResult<IReadOnlyCollection<Driver>>([]);
    public ValueTask<bool> SaveAsync(Driver driver,bool isNew,CancellationToken token)=>ValueTask.FromException<bool>(new InvalidOperationException("El catálogo no está configurado."));
    public ValueTask<bool> DeleteAsync(string code,CancellationToken token)=>ValueTask.FromException<bool>(new InvalidOperationException("El catálogo no está configurado."));
}
