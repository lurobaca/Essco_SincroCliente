using Essco.Application;
using Essco.Application.Configuration;
using Essco.Application.Auditing;
using Essco.Application.Security;
using Essco.Application.Companies;
using Essco.Application.Customers;
using Essco.Infrastructure;
using Essco.Infrastructure.Data;
using Essco.Infrastructure.Security;
using Essco.SapBridge.Contracts;
using Essco.Web.Diagnostics;
using Essco.Web.Security;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
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
builder.Services.AddSingleton<ISapJobQueue, InMemorySapJobQueue>();
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

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();
app.MapHealthChecks("/health").AllowAnonymous();
app.MapGet("/api/sap/jobs", (ISapJobQueue queue) => Results.Ok(queue.GetSnapshot()));
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
