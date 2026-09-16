using Essco.Application;
using Essco.Application.Treasury;
using Essco.Domain;
using Essco.Domain.Treasury;
using Essco.SapBridge.Contracts;

namespace Essco.Tests.Unit.Treasury;

public sealed class IncomingReceiptTests
{
    [Fact] public void Filter_rejects_inverted_dates()=>Assert.NotEmpty(new IncomingReceiptFilter(new(2026,2,2),new(2026,2,1),null,null,null).Validate());
    [Fact] public async Task Dispatch_enqueues_link_with_stable_payload()
    {
        var queue=new QueueStub();var service=new IncomingReceiptService(new RepositoryStub(),queue);
        var result=await service.DispatchAsync(7," 12 "," 44 ",false,"ESSCO","tester",default);
        Assert.True(result.Succeeded);Assert.Equal(IncomingReceiptSapOperations.Link,queue.Request!.OperationType);Assert.Contains("\"DocEntry\":7",queue.Request.Payload);Assert.Contains("\"CollectorCode\":\"12\"",queue.Request.Payload);
    }
    [Fact] public async Task Dispatch_rejects_missing_link_fields()
    { var result=await new IncomingReceiptService(new RepositoryStub(),new QueueStub()).DispatchAsync(7,"","",false,"ESSCO","tester",default);Assert.False(result.Succeeded); }
    private sealed class RepositoryStub:IIncomingReceiptRepository
    { public ValueTask<IReadOnlyCollection<IncomingReceipt>> ListAsync(IncomingReceiptFilter f,CancellationToken t)=>ValueTask.FromResult<IReadOnlyCollection<IncomingReceipt>>([]);public ValueTask<IncomingReceipt?> GetAsync(int id,CancellationToken t)=>ValueTask.FromResult<IncomingReceipt?>(new(id,100,new(2026,1,1),10,"C1","Cliente","","")); }
    private sealed class QueueStub:ISapJobQueue
    { public CreateSapJobRequest? Request{get;private set;}public ValueTask<SapJob> EnqueueAsync(CreateSapJobRequest r,CancellationToken t){Request=r;return ValueTask.FromResult(new SapJob{OperationType=r.OperationType,Company=r.Company,RequestedBy=r.RequestedBy,Payload=r.Payload});}public ValueTask<SapJob?> ClaimNextAsync(CancellationToken t)=>ValueTask.FromResult<SapJob?>(null);public ValueTask CompleteAsync(Guid i,string e,CancellationToken t)=>ValueTask.CompletedTask;public ValueTask FailAsync(Guid i,string e,bool r,CancellationToken t)=>ValueTask.CompletedTask;public ValueTask<IReadOnlyCollection<SapJob>> GetSnapshotAsync(CancellationToken t)=>ValueTask.FromResult<IReadOnlyCollection<SapJob>>([]); }
}
