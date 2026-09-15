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
            var job = await _queue.DequeueAsync(stoppingToken);
            if (job is null)
                continue;

            try
            {
                job.Start();
                logger.LogInformation("Procesando trabajo SAP {JobId} de tipo {OperationType}", job.Id, job.OperationType);

                // La implementación DI API se agregará tras validar versión, arquitectura y ambiente SAP.
                job.Fail("Conector SAP DI API pendiente de configuración.", retryable: true);
            }
            catch (Exception exception)
            {
                logger.LogError(exception, "Falló el trabajo SAP {JobId}", job.Id);
                if (job.Status == SapJobStatus.Processing)
                    job.Fail("Error interno procesando la operación SAP.", retryable: true);
            }
        }
    }
}
