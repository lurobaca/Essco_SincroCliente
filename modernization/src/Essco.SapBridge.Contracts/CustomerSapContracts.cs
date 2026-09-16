namespace Essco.SapBridge.Contracts;

public static class CustomerSapOperations
{
    public const string Create = "Customer.Create";
    public const string Update = "Customer.Update";
    public const string Close = "Customer.Close";
}
public sealed record CustomerSapPayload(long CustomerChangeId);
