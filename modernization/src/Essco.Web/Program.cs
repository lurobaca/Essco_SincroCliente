using Essco.Application;
using Essco.Infrastructure;
using Essco.SapBridge.Contracts;
using Microsoft.AspNetCore.DataProtection;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

// Add services to the container.
builder.Services.AddRazorPages();
var keyDirectory = builder.Configuration["DataProtection:KeyDirectory"]
    ?? Path.Combine(builder.Environment.ContentRootPath, ".keys");
builder.Services.AddDataProtection()
    .SetApplicationName("Essco.Modern")
    .PersistKeysToFileSystem(new DirectoryInfo(keyDirectory));
builder.Services.AddSingleton<ISapJobQueue, InMemorySapJobQueue>();
builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseHttpsRedirection();
}

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();
app.MapHealthChecks("/health");
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
