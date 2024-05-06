using APhoto.Settings;

namespace APhoto.Api.CustomConfiguration
{
    public static class HostCustomConfiguration
    {
        public static IHostBuilder SetCustomHostConfiguration(this IHostBuilder hostBuilder) =>
            hostBuilder.ConfigureAppConfiguration((context, configurationBuilder) =>
            {
                configurationBuilder.Sources.Clear();
                configurationBuilder.AddJsonFile(ProgramSettings.AppSettingsFileName);

                if(context.HostingEnvironment.IsDevelopment())
                {
                    configurationBuilder.AddJsonFile(ProgramSettings.AppSettingsDevelopmentFileName, optional: true);
                }

                configurationBuilder.AddEnvironmentVariables();
            });
    }
}
