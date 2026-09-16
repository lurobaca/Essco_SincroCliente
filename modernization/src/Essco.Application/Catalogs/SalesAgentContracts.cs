using Essco.Domain.Catalogs;

namespace Essco.Application.Catalogs;

public interface ISalesAgentRepository
{
    ValueTask<IReadOnlyCollection<SalesAgent>> ListAsync(string? position, CancellationToken token);
    ValueTask<bool> SaveAsync(SalesAgent agent, bool isNew, CancellationToken token);
    ValueTask<bool> DeleteAsync(string code, CancellationToken token);
}

public sealed class SalesAgentService(ISalesAgentRepository repository)
{
    public ValueTask<IReadOnlyCollection<SalesAgent>> ListAsync(string? position, CancellationToken token) => repository.ListAsync(NormalizePosition(position), token);

    public async ValueTask<(bool Succeeded, IReadOnlyCollection<string> Errors)> SaveAsync(SalesAgent agent, bool isNew, CancellationToken token)
    {
        agent = agent with { Position = agent.Position.Trim().ToUpperInvariant() };
        var errors = agent.Validate();
        if (errors.Count > 0) return (false, errors);
        return await repository.SaveAsync(agent, isNew, token)
            ? (true, [])
            : (false, [isNew ? "Ya existe un agente con ese código." : "El agente ya no existe."]);
    }

    public ValueTask<bool> DeleteAsync(string code, CancellationToken token) => code.Trim() == "3" ? ValueTask.FromResult(false) : repository.DeleteAsync(code, token);

    private static string? NormalizePosition(string? position)
    {
        var value = position?.Trim().ToUpperInvariant();
        return value is "AGENTE" or "CHOFER" or "AYUDANTE" ? value : null;
    }
}
