using Essco.Domain;

namespace Essco.Tests.Unit;

public sealed class SapJobTests
{
    [Fact]
    public void Complete_RequiresProcessingState()
    {
        var job = CreateJob();

        Assert.Throws<InvalidOperationException>(() => job.Complete("123"));
    }

    [Fact]
    public void StartAndComplete_RecordsSuccessfulResult()
    {
        var job = CreateJob();

        job.Start();
        job.Complete("SAP-123");

        Assert.Equal(SapJobStatus.Completed, job.Status);
        Assert.Equal("SAP-123", job.ExternalId);
        Assert.Equal(1, job.Attempts);
    }

    private static SapJob CreateJob() => new()
    {
        OperationType = "CreateInvoice",
        Company = "TEST",
        RequestedBy = "test",
        Payload = "{}"
    };
}
