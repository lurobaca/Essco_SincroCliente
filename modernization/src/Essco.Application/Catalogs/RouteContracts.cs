using Essco.Domain.Catalogs;
namespace Essco.Application.Catalogs;

public interface IRouteRepository { ValueTask<IReadOnlyCollection<OperationalRoute>> ListAsync(CancellationToken token); ValueTask<int> SaveAsync(OperationalRoute route, CancellationToken token); ValueTask<bool> DeleteAsync(int id, CancellationToken token); }
public sealed class RouteService(IRouteRepository repository)
{ public ValueTask<IReadOnlyCollection<OperationalRoute>> ListAsync(CancellationToken t) => repository.ListAsync(t); public async ValueTask<(bool Succeeded, int Id, IReadOnlyCollection<string> Errors)> SaveAsync(OperationalRoute route, CancellationToken t) { var errors = route.Validate(); return errors.Count > 0 ? (false, route.Id, errors) : (true, await repository.SaveAsync(route, t), []); } public ValueTask<bool> DeleteAsync(int id, CancellationToken t) => repository.DeleteAsync(id, t); }
