using Essco.Application.HumanResources;

namespace Essco.Infrastructure.Data;

/// <summary>
/// Indica que la consulta de facturas del empleado requiere configurar SQL Server.
/// </summary>
public sealed class UnavailableEmployeeInvoiceRepository : IEmployeeInvoiceRepository
{
    /// <summary>Rechaza la consulta cuando no existe conexión configurada.</summary>
    public ValueTask<EmployeePendingInvoices> ListPendingInvoicesAsync(
        string customerCode,
        CancellationToken cancellationToken) =>
        ValueTask.FromException<EmployeePendingInvoices>(
            new InvalidOperationException("La consulta de facturas del empleado no está configurada."));
}
