using Essco.Application;
using Essco.Application.Configuration;
using Essco.Application.Companies;
using Essco.Application.Customers;
using Essco.Application.Treasury;
using Essco.Application.Returns;
using Essco.Application.Purchasing;
using Essco.Infrastructure.Data;
using Essco.Infrastructure;
using Essco.SapBridge.Worker;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddWindowsService(options =>
{
    options.ServiceName = "Essco SAP Bridge";
});
var options = builder.Configuration.GetSection(EsscoOptions.SectionName).Get<EsscoOptions>() ?? new();
var connectionString = options.SqlServer.Enabled ? builder.Configuration.GetConnectionString(options.SqlServer.ConnectionStringName) : null;
builder.Services.AddSingleton<ISapJobQueue>(_ => options.SqlServer.Enabled && !string.IsNullOrWhiteSpace(connectionString)
    ? new SqlServerSapJobQueue(connectionString, options.SqlServer.CommandTimeoutSeconds)
    : new InMemorySapJobQueue());
builder.Services.AddOptions<EsscoOptions>().Bind(builder.Configuration.GetSection(EsscoOptions.SectionName))
    .Validate(value => value.Validate().Count == 0, "La configuración Essco no es válida.").ValidateOnStart();
builder.Services.AddSingleton<ICustomerChangeRepository>(_ => options.SqlServer.Enabled && !string.IsNullOrWhiteSpace(connectionString)
    ? new SqlServerCustomerChangeRepository(connectionString, options.SqlServer.CommandTimeoutSeconds)
    : new UnavailableCustomerChangeRepository());
builder.Services.AddSingleton<IGeographyRepository>(_ => options.SqlServer.Enabled && !string.IsNullOrWhiteSpace(connectionString)
    ? new SqlServerGeographyRepository(connectionString, options.SqlServer.CommandTimeoutSeconds)
    : new UnavailableGeographyRepository());
builder.Services.AddSingleton<ISapCustomerGateway, ComSapCustomerGateway>();
builder.Services.AddSingleton<ICustomerSapJobProcessor, CustomerSapJobProcessor>();
builder.Services.AddSingleton<ISapIncomingReceiptGateway, ComSapIncomingReceiptGateway>();
builder.Services.AddSingleton<IIncomingReceiptSapJobProcessor, IncomingReceiptSapJobProcessor>();
builder.Services.AddSingleton<IDepositRepository>(_ => options.SqlServer.Enabled && !string.IsNullOrWhiteSpace(connectionString) ? new SqlServerDepositRepository(connectionString, options.SqlServer.CommandTimeoutSeconds) : new UnavailableDepositRepository());
builder.Services.AddSingleton<ISapDepositGateway, ComSapDepositGateway>();
builder.Services.AddSingleton<IDepositSapJobProcessor, DepositSapJobProcessor>();
builder.Services.AddSingleton<IReturnRepository>(_ => options.SqlServer.Enabled && !string.IsNullOrWhiteSpace(connectionString) ? new SqlServerReturnRepository(connectionString, options.SqlServer.CommandTimeoutSeconds) : new UnavailableReturnRepository());
builder.Services.AddSingleton<ISapReturnGateway, ComSapReturnGateway>();
builder.Services.AddSingleton<IReturnSapJobProcessor, ReturnSapJobProcessor>();
builder.Services.AddSingleton<IPurchaseOrderRepository>(_ => options.SqlServer.Enabled && !string.IsNullOrWhiteSpace(connectionString) ? new SqlServerPurchaseOrderRepository(connectionString, options.SqlServer.CommandTimeoutSeconds) : new UnavailablePurchaseOrderRepository());
builder.Services.AddSingleton<ISapPurchaseOrderGateway, ComSapPurchaseOrderGateway>();
builder.Services.AddSingleton<IPurchaseOrderSapJobProcessor, PurchaseOrderSapJobProcessor>();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
