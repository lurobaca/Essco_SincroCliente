namespace Essco.Application.HumanResources;

/// <summary>
/// Contiene las columnas y los importes devueltos por la consulta heredada de facturas pendientes.
/// </summary>
public sealed record EmployeePendingInvoices(
    IReadOnlyList<string> Columns,
    IReadOnlyList<IReadOnlyList<string>> Rows,
    decimal TotalBalance);

/// <summary>
/// Define la consulta de facturas vinculadas al código de cliente SAP del empleado.
/// </summary>
public interface IEmployeeInvoiceRepository
{
    /// <summary>Obtiene las facturas pendientes del código de cliente indicado.</summary>
    ValueTask<EmployeePendingInvoices> ListPendingInvoicesAsync(
        string customerCode,
        CancellationToken cancellationToken);
}

/// <summary>
/// Normaliza el código de cliente antes de consultar las facturas del empleado.
/// </summary>
public sealed class EmployeeInvoiceService(IEmployeeInvoiceRepository repository)
{
    /// <summary>Consulta las facturas pendientes del cliente vinculado al empleado.</summary>
    public ValueTask<EmployeePendingInvoices> ListPendingInvoicesAsync(
        string customerCode,
        CancellationToken cancellationToken) =>
        repository.ListPendingInvoicesAsync(customerCode.Trim(), cancellationToken);
}
