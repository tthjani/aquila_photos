using Serilog;
using Serilog.Configuration;

namespace APhoto.Api.CustomConfiguration
{
    public static class SerilogLoggingConfiguration
    {
        public static IHostBuilder ConfigureSerilog(this IHostBuilder hostBuilder, Action<IServiceCollection> configureLoggerSettings)
        {
            hostBuilder.ConfigureServices((context, services)
                    => configureLoggerSettings(services));

            hostBuilder.ConfigureServices((context, collection)
                    => collection.AddHostedService<LoggingStartupService>());

            SerilogHostBuilderExtensions.UseSerilog(hostBuilder, (context, provider, configuration) =>
            configuration.ReadFrom.Settings(ServiceProviderServiceExtensions.GetService<ILoggerSettings>(provider)), false, false);

            return hostBuilder;
        }
    }
}
