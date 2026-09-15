using Essco.Application;
using Essco.Infrastructure;
using Essco.SapBridge.Worker;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddWindowsService(options =>
{
    options.ServiceName = "Essco SAP Bridge";
});
builder.Services.AddSingleton<ISapJobQueue, InMemorySapJobQueue>();
builder.Services.AddHostedService<Worker>();

var host = builder.Build();
host.Run();
