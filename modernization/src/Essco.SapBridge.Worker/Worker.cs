using Essco.Application;
using Essco.Application.Customers;
using Essco.Application.Treasury;
using Essco.Domain;

namespace Essco.SapBridge.Worker;

public class Worker(ILogger<Worker> logger, ICustomerSapJobProcessor customerProcessor, IIncomingReceiptSapJobProcessor receiptProcessor) : BackgroundService
{
    private readonly ISapJobQueue _queue = null!;

    public Worker(ILogger<Worker> logger, ICustomerSapJobProcessor customerProcessor, IIncomingReceiptSapJobProcessor receiptProcessor, ISapJobQueue queue) : this(logger, customerProcessor, receiptProcessor)
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

                var result = job.OperationType.StartsWith("Customer.", StringComparison.Ordinal)
                    ? await customerProcessor.ProcessAsync(job.OperationType, job.Payload, stoppingToken)
                    : job.OperationType.StartsWith("IncomingReceipt.", StringComparison.Ordinal)
                        ? await receiptProcessor.ProcessAsync(job.OperationType, job.Payload, stoppingToken)
                        : new SapProcessingResult(false, null, "Tipo de operación SAP no soportado por el servicio.", false);
                if (result.Succeeded)
                    await _queue.CompleteAsync(job.Id, result.ExternalId ?? job.Id.ToString(), stoppingToken);
                else
                    await _queue.FailAsync(job.Id, result.Error ?? "La operación SAP falló.", result.Retryable && job.Attempts < 10, stoppingToken);
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
