using Essco.Application.Billing;

namespace Essco.Tests.Unit.Billing;

/// <summary>
/// Protege el orden heredado de preparación, prioridad y señal FTP sin tocar servidores.
/// </summary>
public sealed class TransmissionDispatchServiceTests
{
    [Fact]
    public async Task ReloadAgent_PreparesSendsAndQueues()
    {
        var events = new List<string>();
        var repository = new RepositoryStub(events);
        var sender = new SignalStub(events);
        var service = new TransmissionDispatchService(repository, sender);

        await service.DispatchAgentAsync("2", reload: true, CancellationToken.None);

        Assert.Equal(["exists:2", "prepare:2:True", "signal:2", "queue:2"], events);
    }

    [Fact]
    public async Task UploadAgent_QueuesBeforeSending()
    {
        var events = new List<string>();
        var service = new TransmissionDispatchService(
            new RepositoryStub(events),
            new SignalStub(events));

        await service.DispatchAgentAsync("2", reload: false, CancellationToken.None);

        Assert.Equal(["exists:2", "prepare:2:False", "queue:2", "signal:2"], events);
    }

    [Fact]
    public async Task ReloadAll_SkipsAgentOneAndKeepsEachAgentSeparate()
    {
        var events = new List<string>();
        var service = new TransmissionDispatchService(
            new RepositoryStub(events),
            new SignalStub(events));

        int completed = await service.DispatchAllAsync(CancellationToken.None);

        Assert.Equal(2, completed);
        Assert.Equal(
            ["prepare:2:True", "signal:2", "queue:2",
             "prepare:3:True", "signal:3", "queue:3"],
            events);
    }

    [Fact]
    public async Task DisabledFtp_DoesNotTouchSql()
    {
        var events = new List<string>();
        var service = new TransmissionDispatchService(
            new RepositoryStub(events),
            new SignalStub(events, configured: false));

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            service.DispatchAgentAsync("2", reload: true, CancellationToken.None));

        Assert.Empty(events);
    }

    [Fact]
    public async Task UnknownAgent_DoesNotClearStatesOrSendSignal()
    {
        var events = new List<string>();
        var service = new TransmissionDispatchService(
            new RepositoryStub(events, agentExists: false),
            new SignalStub(events));

        await Assert.ThrowsAsync<ArgumentException>(() =>
            service.DispatchAgentAsync("99", reload: true, CancellationToken.None));

        Assert.Equal(["exists:99"], events);
    }

    [Fact]
    public async Task FtpFailure_DoesNotQueueReloadAsCompleted()
    {
        var events = new List<string>();
        var service = new TransmissionDispatchService(
            new RepositoryStub(events),
            new SignalStub(events, fail: true));

        await Assert.ThrowsAsync<IOException>(() =>
            service.DispatchAgentAsync("2", reload: true, CancellationToken.None));

        Assert.Equal(["exists:2", "prepare:2:True", "signal:2"], events);
    }

    /// <summary>
    /// Registra las operaciones de SQL necesarias sin ejecutar la base real.
    /// </summary>
    private sealed class RepositoryStub(List<string> events, bool agentExists = true) : ITransmissionStatusRepository
    {
        public Task<bool> AgentExistsAsync(string agent, CancellationToken cancellationToken)
        {
            events.Add($"exists:{agent}");
            return Task.FromResult(agentExists);
        }

        public Task<IReadOnlyList<string>> ListDispatchAgentsAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult<IReadOnlyList<string>>(["1", "2", "3"]);
        }

        public Task PrepareDispatchAsync(string agent, bool reload, CancellationToken cancellationToken)
        {
            events.Add($"prepare:{agent}:{reload}");
            return Task.CompletedTask;
        }

        public Task QueueAgentAsync(string agent, CancellationToken cancellationToken)
        {
            events.Add($"queue:{agent}");
            return Task.CompletedTask;
        }

        public Task<TransmissionSnapshot> ReadAsync(
            string? agent,
            string fileType,
            string status,
            CancellationToken cancellationToken) => throw new NotSupportedException();

        public Task<TransmissionSignals> ReadSignalsAsync(
            CancellationToken cancellationToken) => throw new NotSupportedException();

        public Task<int> ClearAsync(
            string agent,
            string status,
            CancellationToken cancellationToken) => throw new NotSupportedException();

        public Task<int> RetryAsync(
            string agent,
            string file,
            string consecutive,
            string date,
            CancellationToken cancellationToken) => throw new NotSupportedException();

        public Task<int> SetSourceAsync(
            bool downloadFromFtp,
            CancellationToken cancellationToken) => throw new NotSupportedException();
    }

    /// <summary>
    /// Sustituye el FTP para comprobar la secuencia sin emitir señales reales.
    /// </summary>
    private sealed class SignalStub(
        List<string> events,
        bool configured = true,
        bool fail = false) : ITransmissionSignalSender
    {
        public bool IsConfigured => configured;

        public Task SendAsync(string agent, CancellationToken cancellationToken)
        {
            events.Add($"signal:{agent}");
            if (fail)
            {
                throw new IOException("FTP no disponible en la prueba.");
            }
            return Task.CompletedTask;
        }
    }
}
