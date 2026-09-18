using Essco.Application;
using Essco.Application.Returns;
using Essco.Domain;
using Essco.Domain.Returns;
using Essco.SapBridge.Contracts;

namespace Essco.Tests.Unit.Returns;

public sealed class ReturnServiceTests
{
    [Fact]
    public async Task Dispatch_requires_lines()
    {
        var result=await new ReturnService(new Repo(false),new Queue()).DispatchAsync(1,"E","u",default);
        Assert.False(result.Succeeded);
    }

    [Fact]
    public async Task Dispatch_is_idempotent_by_number()
    {
        var queue=new Queue();
        var result=await new ReturnService(new Repo(true),queue).DispatchAsync(1,"E","u",default);
        Assert.True(result.Succeeded);
        Assert.Equal("return:1:credit-note",queue.Request!.IdempotencyKey);
    }

    [Fact]
    public async Task SaveLine_rejects_fractional_quantity_before_repository()
    {
        var repository=new Repo(true);
        var result=await new ReturnService(repository,new Queue()).SaveLineAsync(new(1,1,1.5m,0,0,"M",""),default);
        Assert.False(result.Succeeded);
        Assert.Equal(0,repository.SaveCalls);
    }

    [Fact]
    public async Task SaveLine_accepts_legacy_full_discount()
    {
        var repository=new Repo(true);
        var result=await new ReturnService(repository,new Queue()).SaveLineAsync(new(1,1,2,40,60,"M",""),default);
        Assert.True(result.Succeeded);
        Assert.Equal(1,repository.SaveCalls);
    }

    [Fact]
    public async Task Dispatch_rejects_missing_warehouse()
    {
        var queue=new Queue();
        var result=await new ReturnService(new Repo(true,""),queue).DispatchAsync(1,"E","u",default);
        Assert.False(result.Succeeded);
        Assert.Null(queue.Request);
        Assert.Contains("bodega",result.Error!,StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task AddLine_rejects_invalid_article_before_repository()
    {
        var repository=new Repo(true);
        var result=await new ReturnService(repository,new Queue()).AddLineAsync(new(1,"","Artículo",10,13),default);
        Assert.False(result.Succeeded);
        Assert.Equal(0,repository.AddCalls);
    }

    [Fact]
    public async Task DeleteLine_delegates_valid_identity()
    {
        var repository=new Repo(true);
        var result=await new ReturnService(repository,new Queue()).DeleteLineAsync(1,0,default);
        Assert.True(result.Succeeded);
        Assert.Equal(1,repository.DeleteCalls);
    }

    [Fact]
    public async Task Dispatch_rejects_incomplete_new_line()
    {
        var queue=new Queue();
        var result=await new ReturnService(new Repo(true,"01",0),queue).DispatchAsync(1,"E","u",default);
        Assert.False(result.Succeeded);
        Assert.Null(queue.Request);
        Assert.Contains("cantidad",result.Error!,StringComparison.OrdinalIgnoreCase);
    }

    private sealed class Repo(bool lines,string warehouse="01",decimal quantity=1):IReturnRepository
    {
        public int SaveCalls {get;private set;}
        public int AddCalls {get;private set;}
        public int DeleteCalls {get;private set;}
        public ValueTask<ReturnRequest?> GetAsync(int number,CancellationToken token)=>
            ValueTask.FromResult<ReturnRequest?>(new(number,new(2026,1,1),"1","A","C1","C",false,10,"F","M",false,null,"","","",
                lines?[new(1,"I","Item",10,quantity,0,0,13,10,"M","",warehouse)]:[]));
        public ValueTask<IReadOnlyCollection<ReturnRequest>> ListAsync(ReturnFilter filter,CancellationToken token)=>
            ValueTask.FromResult<IReadOnlyCollection<ReturnRequest>>([]);
        public ValueTask<bool> SaveLineAsync(ReturnLineDraft line,CancellationToken token){SaveCalls++;return ValueTask.FromResult(true);}
        public ValueTask<bool> AddLineAsync(NewReturnLine line,CancellationToken token){AddCalls++;return ValueTask.FromResult(true);}
        public ValueTask<bool> DeleteLineAsync(int number,int lineNumber,CancellationToken token){DeleteCalls++;return ValueTask.FromResult(true);}
        public ValueTask<bool> MarkProcessedAsync(int number,int entry,CancellationToken token)=>ValueTask.FromResult(true);
    }

    private sealed class Queue:ISapJobQueue
    {
        public CreateSapJobRequest? Request {get;private set;}
        public ValueTask<SapJob> EnqueueAsync(CreateSapJobRequest request,CancellationToken token)
        {Request=request;return ValueTask.FromResult(new SapJob{OperationType=request.OperationType,Company=request.Company,RequestedBy=request.RequestedBy,Payload=request.Payload});}
        public ValueTask<SapJob?> ClaimNextAsync(CancellationToken token)=>ValueTask.FromResult<SapJob?>(null);
        public ValueTask CompleteAsync(Guid id,string externalId,CancellationToken token)=>ValueTask.CompletedTask;
        public ValueTask FailAsync(Guid id,string error,bool retry,CancellationToken token)=>ValueTask.CompletedTask;
        public ValueTask<IReadOnlyCollection<SapJob>> GetSnapshotAsync(CancellationToken token)=>ValueTask.FromResult<IReadOnlyCollection<SapJob>>([]);
    }
}
