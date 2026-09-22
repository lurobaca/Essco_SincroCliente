using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using Essco.Domain.Customers;

namespace Essco.Application.Customers;

public static class CustomerRequestFingerprint
{
    // La aprobación es un estado de entrega, no forma parte de los datos enviados del cliente.
    // Nunca persiste el origen serializado: podría incluir la contraseña Web heredada.
    public static string Compute(CustomerChangeRequest customer) =>
        Convert.ToHexString(SHA256.HashData(Encoding.UTF8.GetBytes(
            JsonSerializer.Serialize(customer with { Approved = false }))));
}
