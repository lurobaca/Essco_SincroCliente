namespace Essco.Application.Billing;

/// <summary>
/// Conserva el orden de limpieza, recarga, prioridad y señal del formulario WinForms.
/// </summary>
public sealed class TransmissionDispatchService(
    ITransmissionStatusRepository repository,
    ITransmissionSignalSender signalSender)
{
    private static readonly SemaphoreSlim ExecutionLock = new(1, 1);

    public bool IsConfigured => signalSender.IsConfigured;

    /// <summary>
    /// Envía un agente según el botón original; rechaza una ejecución simultánea en este servidor.
    /// </summary>
    public async Task DispatchAgentAsync(
        string agent,
        bool reload,
        CancellationToken cancellationToken)
    {
        EnsureConfigured();
        if (!await ExecutionLock.WaitAsync(0, cancellationToken))
        {
            throw new InvalidOperationException("Ya hay una transmisión en curso en este servidor.");
        }

        try
        {
            if (!await repository.AgentExistsAsync(agent, cancellationToken))
            {
                throw new ArgumentException("El número indicado no corresponde a un agente.", nameof(agent));
            }

            await DispatchOneAsync(agent, reload, cancellationToken);
        }
        finally
        {
            ExecutionLock.Release();
        }
    }

    /// <summary>
    /// Recorre los agentes del catálogo, excepto el código 1 como hace WinForms.
    /// </summary>
    public async Task<int> DispatchAllAsync(CancellationToken cancellationToken)
    {
        EnsureConfigured();
        if (!await ExecutionLock.WaitAsync(0, cancellationToken))
        {
            throw new InvalidOperationException("Ya hay una transmisión en curso en este servidor.");
        }

        try
        {
            IReadOnlyList<string> agents = await repository.ListDispatchAgentsAsync(cancellationToken);
            int completed = 0;
            foreach (string agent in agents.Where(code => code != "1"))
            {
                cancellationToken.ThrowIfCancellationRequested();
                await DispatchOneAsync(agent, reload: true, cancellationToken);
                completed++;
            }

            return completed;
        }
        finally
        {
            ExecutionLock.Release();
        }
    }

    /// <summary>
    /// Sigue el orden de cada botón, sin limpiar estados de agentes ajenos en Recargar Todos.
    /// </summary>
    private async Task DispatchOneAsync(
        string agent,
        bool reload,
        CancellationToken cancellationToken)
    {
        await repository.PrepareDispatchAsync(agent, reload, cancellationToken);
        if (reload)
        {
            await signalSender.SendAsync(agent, cancellationToken);
            await repository.QueueAgentAsync(agent, cancellationToken);
            return;
        }

        await repository.QueueAgentAsync(agent, cancellationToken);
        await signalSender.SendAsync(agent, cancellationToken);
    }

    /// <summary>
    /// Impide modificar SQL si todavía no hay un destino FTP habilitado.
    /// </summary>
    private void EnsureConfigured()
    {
        if (!signalSender.IsConfigured)
        {
            throw new InvalidOperationException("El FTP de transmisiones no está habilitado.");
        }
    }
}
