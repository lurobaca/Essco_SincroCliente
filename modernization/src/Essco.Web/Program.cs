using Essco.Application;
using Essco.Application.Configuration;
using Essco.Application.Auditing;
using Essco.Application.Security;
using Essco.Application.Companies;
using Essco.Application.Customers;
using Essco.Application.Catalogs;
using Essco.Application.Treasury;
using Essco.Application.Liquidations;
using Essco.Application.Returns;
using Essco.Application.Products;
using Essco.Application.Purchasing;
using Essco.Application.Billing;
using Essco.Application.Inventory;
using Essco.Application.Payroll;
using Essco.Application.HumanResources;
using Essco.Infrastructure;
using Essco.Infrastructure.Data;
using Essco.Infrastructure.Security;
using Essco.SapBridge.Contracts;
using Essco.Web.Diagnostics;
using Essco.Web.Security;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
if (builder.Environment.IsDevelopment())
{
    // Machine-specific settings stay outside source control; explicit overrides retain priority.
    builder.Configuration.AddJsonFile("appsettings.Local.json", optional: true, reloadOnChange: false)
        .AddUserSecrets(typeof(Program).Assembly, optional: true)
        .AddEnvironmentVariables().AddCommandLine(args);
}
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
        options.Cookie.Name = "__Host-Essco.Auth";
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
        options.Cookie.SameSite = SameSiteMode.Strict;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
        options.SlidingExpiration = true;
    });
var authorization = builder.Services.AddAuthorizationBuilder()
    .SetFallbackPolicy(new Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build());
foreach (var permission in Permissions.All)
    authorization.AddPolicy(permission, policy => policy.Requirements.Add(new PermissionRequirement(permission)));
builder.Services.AddSingleton<Microsoft.AspNetCore.Authorization.IAuthorizationHandler, PermissionAuthorizationHandler>();
builder.Services.AddProblemDetails(options =>
{
    options.CustomizeProblemDetails = context =>
        context.ProblemDetails.Extensions["correlationId"] = context.HttpContext.TraceIdentifier;
});
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddOptions<EsscoOptions>()
    .Bind(builder.Configuration.GetSection(EsscoOptions.SectionName))
    .Validate(options => options.Validate().Count == 0, "La configuración Essco no es válida.")
    .ValidateOnStart();
var keyDirectory = builder.Configuration["DataProtection:KeyDirectory"]
    ?? Path.Combine(builder.Environment.ContentRootPath, ".keys");
builder.Services.AddDataProtection()
    .SetApplicationName("Essco.Modern")
    .PersistKeysToFileSystem(new DirectoryInfo(keyDirectory));
builder.Services.AddSingleton<IPasswordService, Pbkdf2PasswordService>();
builder.Services.AddSingleton(TimeProvider.System);
builder.Services.AddSingleton(AuthenticationPolicy.Default);
builder.Services.AddSingleton(PasswordPolicy.Default);
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<PasswordChangeService>();

var initialOptions = builder.Configuration.GetSection(EsscoOptions.SectionName).Get<EsscoOptions>() ?? new();
var sqlConnectionString = initialOptions.SqlServer.Enabled
    ? builder.Configuration.GetConnectionString(initialOptions.SqlServer.ConnectionStringName)
    : null;
var sapSqlConnectionString = builder.Configuration.GetConnectionString("SapSqlServer");
builder.Services.AddSingleton<ISapJobQueue>(_ =>
    initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString)
        ? new SqlServerSapJobQueue(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds)
        : new InMemorySapJobQueue());
builder.Services.AddScoped<IUserAccountRepository>(_ =>
    initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString)
        ? new SqlServerUserAccountRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds)
        : new UnavailableUserAccountRepository());
builder.Services.AddScoped<IAuditSink>(_ =>
    initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString)
        ? new SqlServerAuditSink(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds)
        : new UnavailableAuditSink());
builder.Services.AddScoped<AuditService>();
builder.Services.AddScoped<ICompanyRepository>(_ =>
    initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString)
        ? new SqlServerCompanyRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds)
        : new UnavailableCompanyRepository());
builder.Services.AddScoped<IGeographyRepository>(_ =>
    initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString)
        ? new SqlServerGeographyRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds)
        : new UnavailableGeographyRepository());
builder.Services.AddScoped<CompanyService>();
builder.Services.AddScoped<ICustomerChangeRepository>(_ =>
    initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString)
        ? new SqlServerCustomerChangeRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds)
        : new UnavailableCustomerChangeRepository());
builder.Services.AddScoped<CustomerChangeService>();
builder.Services.AddScoped<CustomerSapDispatchService>();
builder.Services.AddScoped<ICustomerExemptionRepository>(_ =>
    initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString)
        ? new SqlServerCustomerExemptionRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds)
        : new UnavailableCustomerExemptionRepository());
builder.Services.AddScoped<CustomerExemptionService>();
builder.Services.AddScoped<IAccountStatementRepository>(_ =>
    initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString)
        ? new SqlServerAccountStatementRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds)
        : new UnavailableAccountStatementRepository());
builder.Services.AddScoped<AccountStatementService>();
builder.Services.AddScoped<IReturnReasonRepository>(_ =>
    initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString)
        ? new SqlServerReturnReasonRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds, initialOptions.Sap.CompanyDatabase)
        : new UnavailableReturnReasonRepository());
builder.Services.AddScoped<ReturnReasonService>();
builder.Services.AddScoped<IRouteRepository>(_ => initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString) ? new SqlServerRouteRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds) : new UnavailableRouteRepository());
builder.Services.AddScoped<RouteService>();
builder.Services.AddScoped<IBankRepository>(_ => initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString) ? new SqlServerBankRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds) : new UnavailableBankRepository());
builder.Services.AddScoped<BankService>();
builder.Services.AddScoped<INoVisitReasonRepository>(_ => initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString) ? new SqlServerNoVisitReasonRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds) : new UnavailableNoVisitReasonRepository());
builder.Services.AddScoped<NoVisitReasonService>();
builder.Services.AddScoped<IWarehouseRepository>(_ => initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString) ? new SqlServerWarehouseRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds) : new UnavailableWarehouseRepository());
builder.Services.AddScoped<WarehouseService>();
builder.Services.AddScoped<IWarehouseOperatorRepository>(_ => initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString) ? new SqlServerWarehouseOperatorRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds) : new UnavailableWarehouseOperatorRepository());
builder.Services.AddScoped<WarehouseOperatorService>();
builder.Services.AddScoped<ISalesAgentRepository>(_ => initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString) ? new SqlServerSalesAgentRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds) : new UnavailableSalesAgentRepository());
builder.Services.AddScoped<SalesAgentService>();
builder.Services.AddScoped<IDriverRepository>(_ => initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString) ? new SqlServerDriverRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds) : new UnavailableDriverRepository());
builder.Services.AddScoped<DriverService>();
builder.Services.AddScoped<IDepositRepository>(_ => initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString) ? new SqlServerDepositRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds) : new UnavailableDepositRepository());
builder.Services.AddScoped<DepositService>();
builder.Services.AddScoped<DepositSapDispatchService>();
builder.Services.AddScoped<IIncomingReceiptRepository>(_ => initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString) && !string.IsNullOrWhiteSpace(initialOptions.Sap.CompanyDatabase) ? new SqlServerIncomingReceiptRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds, initialOptions.Sap.CompanyDatabase) : new UnavailableIncomingReceiptRepository());
builder.Services.AddScoped<IncomingReceiptService>();
builder.Services.AddScoped<ILiquidationRepository>(_ => initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString) ? new SqlServerLiquidationRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds, initialOptions.Sap.CompanyDatabase) : new UnavailableLiquidationRepository());
builder.Services.AddScoped<LiquidationService>();
builder.Services.AddScoped<ILiquidationExpenseRepository>(_ => initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString) ? new SqlServerLiquidationExpenseRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds) : new UnavailableLiquidationExpenseRepository());
builder.Services.AddScoped<LiquidationExpenseService>();
builder.Services.AddScoped<IReturnRepository>(_ => initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString) ? new SqlServerReturnRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds) : new UnavailableReturnRepository());
builder.Services.AddScoped<ReturnService>();
builder.Services.AddScoped<IProductRepository>(_ => initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString) ? new SqlServerProductRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds) : new UnavailableProductRepository());
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<IPurchaseOrderRepository>(_ => initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString) ? new SqlServerPurchaseOrderRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds) : new UnavailablePurchaseOrderRepository());
builder.Services.AddScoped<PurchaseOrderService>();
builder.Services.AddScoped<IElectronicInvoiceRepository>(_ => initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString) ? new SqlServerElectronicInvoiceRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds) : new UnavailableElectronicInvoiceRepository());
builder.Services.AddScoped<ElectronicInvoiceService>();
builder.Services.AddScoped<IInventoryRepository>(_ => initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString) ? new SqlServerInventoryRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds) : new UnavailableInventoryRepository());
builder.Services.AddScoped<InventoryService>();
builder.Services.AddScoped<IInventoryCountCompletion>(_ => initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString) ? new SqlServerInventoryCountCompletion(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds) : new UnavailableInventoryCountCompletion());
builder.Services.AddScoped<IInventoryConsolidationRepository>(_ => initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString) ? new SqlServerInventoryConsolidationRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds) : new UnavailableInventoryConsolidationRepository());
builder.Services.AddScoped<IInventoryRecountRepository>(_ => initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString) ? new SqlServerInventoryRecountRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds) : new UnavailableInventoryRecountRepository());
builder.Services.AddScoped<IInventoryConsolidationReadiness>(_ => initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString) ? new SqlServerInventoryConsolidationReadiness(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds) : new UnavailableInventoryConsolidationReadiness());
builder.Services.AddScoped<IInventoryCrossingRepository>(_ => initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString) ? new SqlServerInventoryCrossingRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds) : new UnavailableInventoryCrossingRepository());
builder.Services.AddScoped<IInventoryCreationRepository>(_ => initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString) ? new SqlServerInventoryCreationRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds) : new UnavailableInventoryCreationRepository());
builder.Services.AddScoped<InventoryCreationService>();
builder.Services.AddScoped<IPayrollRepository>(_ => initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString) ? new SqlServerPayrollRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds) : new UnavailablePayrollRepository());
builder.Services.AddScoped<PayrollService>();
builder.Services.AddScoped<IPayrollBankRepository>(_ => initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString) ? new SqlServerPayrollBankRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds) : new UnavailablePayrollBankRepository());
builder.Services.AddScoped<PayrollBankFileService>();
builder.Services.AddScoped<IPayrollJournalRepository>(_ => initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString) ? new SqlServerPayrollJournalRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds) : new UnavailablePayrollJournalRepository());
builder.Services.AddScoped<PayrollSapDispatchService>();
builder.Services.AddScoped<IEmployeeRepository>(_ => initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString) ? new SqlServerEmployeeRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds, initialOptions.Sap.CompanyDatabase, sapSqlConnectionString) : new UnavailableEmployeeRepository());
builder.Services.AddScoped<EmployeeService>();
builder.Services.AddScoped<IEmployeeMovementRepository>(_ => initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString) ? new SqlServerEmployeeMovementRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds) : new UnavailableEmployeeMovementRepository());
builder.Services.AddScoped<EmployeeMovementService>();
builder.Services.AddScoped<IEmployeeCompensationRepository>(_ => initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString) ? new SqlServerEmployeeCompensationRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds) : new UnavailableEmployeeCompensationRepository());
builder.Services.AddScoped<EmployeeCompensationService>();
builder.Services.AddScoped<IEmployeeAttachmentRepository>(_ => initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString) ? new SqlServerEmployeeAttachmentRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds) : new UnavailableEmployeeAttachmentRepository());
builder.Services.AddScoped<IEmployeeBackgroundRepository>(_ => initialOptions.SqlServer.Enabled && !string.IsNullOrWhiteSpace(sqlConnectionString) ? new SqlServerEmployeeBackgroundRepository(sqlConnectionString, initialOptions.SqlServer.CommandTimeoutSeconds) : new UnavailableEmployeeBackgroundRepository());
builder.Services.AddScoped<EmployeeBackgroundService>();
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseHttpsRedirection();
}

app.UseExceptionHandler();
app.UseMiddleware<CorrelationIdMiddleware>();

app.UseRouting();

app.UseAuthentication();
app.UseMiddleware<PasswordChangeRequiredMiddleware>();
app.UseAuthorization();

// Public CSS/JS must load on anonymous pages such as the dashboard and login.
// Business pages retain the authenticated fallback policy and their permissions.
app.MapStaticAssets().AllowAnonymous().WithMetadata(new PublicStaticAssetMetadata());
app.MapRazorPages()
   .WithStaticAssets();
app.MapHealthChecks("/health").AllowAnonymous();
app.MapGet("/api/sap/jobs", async (ISapJobQueue queue, CancellationToken cancellationToken) =>
    Results.Ok(await queue.GetSnapshotAsync(cancellationToken)));
app.MapPost("/api/sap/jobs", async (CreateSapJobRequest request, ISapJobQueue queue, CancellationToken cancellationToken) =>
{
    if (string.IsNullOrWhiteSpace(request.OperationType) ||
        string.IsNullOrWhiteSpace(request.Company) ||
        string.IsNullOrWhiteSpace(request.IdempotencyKey))
        return Results.ValidationProblem(new Dictionary<string, string[]>
        {
            ["request"] = ["Operación, empresa y clave de idempotencia son obligatorias."]
        });

    var job = await queue.EnqueueAsync(request, cancellationToken);
    return Results.Accepted($"/api/sap/jobs/{job.Id}", job);
});

app.Run();
