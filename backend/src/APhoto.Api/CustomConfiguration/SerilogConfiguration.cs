using Serilog;
using Serilog.Configuration;

namespace APhoto.Api.CustomConfiguration
{
    public class SerilogConfiguration : ILoggerSettings
    {
        private readonly IConfiguration _configuration;

        public SerilogConfiguration(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(LoggerConfiguration loggerConfiguration)
        {
            loggerConfiguration.ReadFrom.Configuration(_configuration);
        }
    }
}
