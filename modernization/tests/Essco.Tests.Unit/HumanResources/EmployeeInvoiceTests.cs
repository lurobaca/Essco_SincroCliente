using Essco.Application.HumanResources;

namespace Essco.Tests.Unit.HumanResources;

/// <summary>
/// Verifica que las facturas se consulten con el código de cliente normalizado.
/// </summary>
public sealed class EmployeeInvoiceTests
{
    [Fact]
    public async Task Removes_outer_spaces_from_customer_code()
    {
        var repository = new InvoiceRepository();
        var service = new EmployeeInvoiceService(repository);

        await service.ListPendingInvoicesAsync("  C001  ", CancellationToken.None);

        Assert.Equal("C001", repository.LastCustomerCode);
    }

    private sealed class InvoiceRepository : IEmployeeInvoiceRepository
    {
        public string? LastCustomerCode { get; private set; }

        /// <summary>Conserva el código recibido para verificar la normalización.</summary>
        public ValueTask<EmployeePendingInvoices> ListPendingInvoicesAsync(
            string customerCode,
            CancellationToken cancellationToken)
        {
            LastCustomerCode = customerCode;
            return ValueTask.FromResult(new EmployeePendingInvoices([], [], 0));
        }
    }
}
