using Essco.Application;
using Essco.Application.Configuration;
using Essco.Infrastructure.Data;
using Essco.Infrastructure;
using Essco.SapBridge.Worker;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddWindowsService(options =>
{
    options.ServiceName = "Essco SAP Bridge";
});
var options=builder.Configuration.GetSection(EsscoOptions.SectionName).Get<EsscoOptions>()??new();
var connectionString=options.SqlServer.Enabled?builder.Configuration.GetConnectionString(options.SqlServer.ConnectionStringName):null;
builder.Services.AddSingleton<ISapJobQueue>(_=>options.SqlServer.Enabled&&!string.IsNullOrWhiteSpace(connectionString)
    ?new SqlServerSapJobQueue(connectionString,options.SqlServer.CommandTimeoutSeconds)
    :new InMemorySapJobQueue());
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
