namespace Essco.Application.HumanResources;

public interface IEmployeeAttachmentRepository
{
    ValueTask<byte[]?> GetAsync(string employee, string kind, int number, CancellationToken token);
    ValueTask<bool> SaveAsync(string employee, string kind, int number, byte[] content, CancellationToken token);
}

public static class EmployeeAttachment
{
    public const int MaximumBytes = 5 * 1024 * 1024;
    public static bool ValidKind(string kind) => kind is "vacation" or "disability" or "loan";
    public static string? Extension(byte[] content)
    {
        if (content.Length is 0 or > MaximumBytes) return null;
        if (content.AsSpan().StartsWith(new byte[] { 137, 80, 78, 71, 13, 10, 26, 10 })) return ".png";
        if (content.AsSpan().StartsWith(new byte[] { 255, 216, 255 })) return ".jpg";
        return null;
    }
}
