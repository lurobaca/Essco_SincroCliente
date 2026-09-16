using Essco.Application;
using Essco.Application.Catalogs;
using Essco.Application.Customers;
using Essco.Application.Treasury;
using Essco.Domain;
using Essco.Domain.Catalogs;
using Essco.Domain.Treasury;
using Essco.SapBridge.Contracts;

namespace Essco.Tests.Unit.Treasury;

public sealed class DepositSapTests
{
    [Fact] public async Task Dispatch_uses_bank_account_and_enqueues_once()
    { var queue=new QueueStub();var result=await new DepositSapDispatchService(new DepositRepository(),new BankRepository(),queue).DispatchAsync(3,"ESSCO","tester",default);Assert.True(result.Succeeded);Assert.Contains("10100102001",queue.Request!.Payload);Assert.Equal("deposit:3:create",queue.Request.IdempotencyKey); }
    [Fact] public async Task Processor_marks_uploaded_only_after_sap_success()
    { var repository=new DepositRepository();var payload=System.Text.Json.JsonSerializer.Serialize(new DepositSapPayload(3,"D1",new(2026,1,2),"Banco", "101",25,"9"));var result=await new DepositSapJobProcessor(repository,new Gateway()).ProcessAsync(DepositSapOperations.Create,payload,default);Assert.True(result.Succeeded);Assert.True(repository.Marked); }
    private sealed class DepositRepository:IDepositRepository
    { public bool Marked{get;private set;}private static Deposit Item=>new(){Consecutive=3,Number="D1",Date=new(2026,1,1),AccountingDate=new(2026,1,2),Bank="Banco",Amount=25,EmployeeCode="1",Notes="",LiquidationNumber="9",LiquidationType="AGENTES"};public ValueTask<IReadOnlyCollection<Deposit>> ListAsync(DepositFilter f,CancellationToken t)=>ValueTask.FromResult<IReadOnlyCollection<Deposit>>([Item with{IsUploaded=Marked}]);public ValueTask<bool> MarkUploadedAsync(int c,CancellationToken t){Marked=true;return ValueTask.FromResult(true);}public ValueTask<IReadOnlyCollection<string>> ListBanksAsync(CancellationToken t)=>ValueTask.FromResult<IReadOnlyCollection<string>>([]);public ValueTask<DepositWriteResult>CreateAsync(Deposit d,CancellationToken t)=>throw new NotImplementedException();public ValueTask<DepositWriteResult>UpdateAsync(Deposit d,CancellationToken t)=>throw new NotImplementedException();public ValueTask<bool>AnnulAsync(int c,CancellationToken t)=>throw new NotImplementedException();public ValueTask<bool>LinkLiquidationAsync(int c,string n,string y,CancellationToken t)=>throw new NotImplementedException(); }
    private sealed class BankRepository:IBankRepository
    { public ValueTask<IReadOnlyCollection<CompanyBank>> ListAsync(CancellationToken t)=>ValueTask.FromResult<IReadOnlyCollection<CompanyBank>>([new(){Code="B",Name="Banco",Account="10100102001"}]);public ValueTask CreateAsync(CompanyBank b,CancellationToken t)=>throw new NotImplementedException();public ValueTask<bool>DeleteAsync(string c,CancellationToken t)=>throw new NotImplementedException(); }
    private sealed class Gateway:ISapDepositGateway { public ValueTask<SapProcessingResult>CreateAsync(DepositSapPayload d,CancellationToken t)=>ValueTask.FromResult(new SapProcessingResult(true,"77",null,false)); }
    private sealed class QueueStub:ISapJobQueue
    { public CreateSapJobRequest? Request{get;private set;}public ValueTask<SapJob>EnqueueAsync(CreateSapJobRequest r,CancellationToken t){Request=r;return ValueTask.FromResult(new SapJob{OperationType=r.OperationType,Company=r.Company,RequestedBy=r.RequestedBy,Payload=r.Payload});}public ValueTask<SapJob?>ClaimNextAsync(CancellationToken t)=>ValueTask.FromResult<SapJob?>(null);public ValueTask CompleteAsync(Guid i,string e,CancellationToken t)=>ValueTask.CompletedTask;public ValueTask FailAsync(Guid i,string e,bool r,CancellationToken t)=>ValueTask.CompletedTask;public ValueTask<IReadOnlyCollection<SapJob>>GetSnapshotAsync(CancellationToken t)=>ValueTask.FromResult<IReadOnlyCollection<SapJob>>([]); }
}
