using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Essco.Domain.Customers;

namespace Essco.Application.Customers;

public static class CustomerRequestFingerprint
{
    // Approval is delivery state, not part of the submitted customer data.
    // Never persist the serialized source: it may include the legacy web password.
    public static string Compute(CustomerChangeRequest customer) =>
        Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(
            JsonSerializer.Serialize(customer with { Approved = false }))));
}
