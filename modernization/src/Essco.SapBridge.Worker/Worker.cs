using Essco.Application;
using Essco.Domain;

namespace Essco.SapBridge.Worker;

public class Worker(ILogger<Worker> logger) : BackgroundService
{
    private readonly ISapJobQueue _queue = null!;

    public Worker(ILogger<Worker> logger, ISapJobQueue queue) : this(logger)
    {
        _queue = queue;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var job = await _queue.ClaimNextAsync(stoppingToken);
            if (job is null)
            {
                await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
                continue;
            }

            try
            {
                logger.LogInformation("Procesando trabajo SAP {JobId} de tipo {OperationType}", job.Id, job.OperationType);

                // La implementación DI API se agregará tras validar versión, arquitectura y ambiente SAP.
                await _queue.FailAsync(job.Id, "Conector SAP DI API pendiente de configuración.", retryable: job.Attempts < 10, stoppingToken);
                if (job.Attempts < 10) await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "Falló el trabajo SAP {JobId}", job.Id);
                if (job.Status == SapJobStatus.Processing)
                    await _queue.FailAsync(job.Id, "Error interno procesando la operación SAP.", retryable: true, stoppingToken);
            }
        }
    }
}
