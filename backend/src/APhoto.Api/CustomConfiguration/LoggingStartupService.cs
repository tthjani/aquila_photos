using Serilog;
using System.Reflection;

namespace APhoto.Api.CustomConfiguration
{
    public class LoggingStartupService : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            string name = Assembly.GetEntryAssembly()!.GetName().Name!;
            Version version = Assembly.GetEntryAssembly()!.GetName().Version!;
            Log.Verbose("Logging initialised with level [Verbose] for {0} version {1}", name, version);
            Log.Debug("Logging initialised with level [Debug] for {0} version {1}", name, version);
            Log.Information("Logging initialised with level [Information] for {0} version {1}", name, version);
            Log.Warning("Logging initialised with level [Warning] for {0} version {1}", name, version);
            Log.Error("Logging initialised with level [Error] for {0} version {1}", name, version);
            Log.Fatal("Logging initialised with level [Fatal] for {0} version {1}", name, version);
            return Task.CompletedTask;
        }
    }
}
