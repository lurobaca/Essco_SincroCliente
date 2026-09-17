using Essco.Application.HumanResources;
namespace Essco.Infrastructure.Data;
public sealed class UnavailableEmployeeAttachmentRepository : IEmployeeAttachmentRepository
{
    public ValueTask<byte[]?> GetAsync(string employee, string kind, int number, CancellationToken token) => ValueTask.FromResult<byte[]?>(null);
    public ValueTask<bool> SaveAsync(string employee, string kind, int number, byte[] content, CancellationToken token) => ValueTask.FromResult(false);
}
