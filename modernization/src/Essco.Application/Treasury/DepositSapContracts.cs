using System.Text.Json;
using Essco.Application.Catalogs;
using Essco.Application.Customers;
using Essco.Domain;
using Essco.SapBridge.Contracts;

namespace Essco.Application.Treasury;

public static class DepositSapOperations { public const string Create = "Deposit.Create"; }
public sealed record DepositSapPayload(int Consecutive, string Number, DateOnly AccountingDate, string Bank,
    string BankAccount, decimal Amount, string LiquidationNumber);

public sealed class DepositSapDispatchService(IDepositRepository deposits, IBankRepository banks, ISapJobQueue queue)
{
    public async ValueTask<(bool Succeeded, SapJob? Job, string? Error)> DispatchAsync(int consecutive,
        string company, string requestedBy, CancellationToken token)
    {
        var deposit = (await deposits.ListAsync(new(Consecutive: consecutive, IncludeAnnulled: true), token)).SingleOrDefault();
        if (deposit is null) return (false, null, "El depósito no existe.");
        if (deposit.IsAnnulled) return (false, null, "Un depósito anulado no se puede enviar a SAP.");
        if (deposit.IsUploaded) return (false, null, "El depósito ya fue enviado a SAP.");
        if (deposit.HasReceipt) return (false, null, "El registro está marcado como boleta y no debe crear un depósito en SAP.");
        var bank = (await banks.ListAsync(token)).FirstOrDefault(x => string.Equals(x.Name.Trim(), deposit.Bank.Trim(), StringComparison.OrdinalIgnoreCase));
        if (bank is null || string.IsNullOrWhiteSpace(bank.Account)) return (false, null, $"El banco {deposit.Bank} no tiene una cuenta SAP configurada.");
        var payload = new DepositSapPayload(deposit.Consecutive, deposit.Number, deposit.AccountingDate, deposit.Bank,
            bank.Account.Trim(), deposit.Amount, deposit.LiquidationNumber);
        var request = new CreateSapJobRequest(DepositSapOperations.Create, company, requestedBy,
            JsonSerializer.Serialize(payload), $"deposit:{deposit.Consecutive}:create");
        return (true, await queue.EnqueueAsync(request, token), null);
    }
}

public interface ISapDepositGateway { ValueTask<SapProcessingResult> CreateAsync(DepositSapPayload deposit, CancellationToken token); }
public interface IDepositSapJobProcessor { ValueTask<SapProcessingResult> ProcessAsync(string operation, string payload, CancellationToken token); }
public sealed class DepositSapJobProcessor(IDepositRepository deposits, ISapDepositGateway gateway) : IDepositSapJobProcessor
{
    public async ValueTask<SapProcessingResult> ProcessAsync(string operation, string payload, CancellationToken token)
    {
        if (operation != DepositSapOperations.Create) return new(false, null, "Operación de depósito no soportada.", false);
        DepositSapPayload? request;
        try { request = JsonSerializer.Deserialize<DepositSapPayload>(payload); }
        catch (JsonException) { return new(false, null, "Payload de depósito inválido.", false); }
        if (request is null || request.Consecutive <= 0 || request.Amount <= 0 || string.IsNullOrWhiteSpace(request.BankAccount)) return new(false, null, "Payload de depósito incompleto.", false);
        var current = (await deposits.ListAsync(new(Consecutive: request.Consecutive, IncludeAnnulled: true), token)).SingleOrDefault();
        if (current is null || current.IsAnnulled) return new(false, null, "El depósito ya no existe o fue anulado.", false);
        if (current.IsUploaded) return new(true, current.Number, null, false);
        var result = await gateway.CreateAsync(request, token);
        if (!result.Succeeded) return result;
        return await deposits.MarkUploadedAsync(request.Consecutive, token)
            ? result
            : new(false, result.ExternalId, "SAP creó el depósito, pero no se pudo marcar como subido en SQL. Requiere conciliación manual para evitar duplicarlo.", false);
    }
}
