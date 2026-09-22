using Essco.Application.Billing;
using Essco.Domain.Billing;
namespace Essco.Infrastructure.Data; public sealed class UnavailableElectronicInvoiceRepository : IElectronicInvoiceRepository { public ValueTask<IReadOnlyCollection<ElectronicInvoice>> ListAsync(ElectronicInvoiceFilter f, CancellationToken t) => ValueTask.FromResult<IReadOnlyCollection<ElectronicInvoice>>([]); public ValueTask<ElectronicInvoice?> GetAsync(string n, CancellationToken t) => ValueTask.FromResult<ElectronicInvoice?>(null); }
