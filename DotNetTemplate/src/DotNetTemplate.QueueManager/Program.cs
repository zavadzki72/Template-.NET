using DotNetTemplate.CrossCutting.IoC;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DotNetTemplate.QueueManager {
    public class Program {
        public static async Task Main(string[] args) {

            var builder = new HostBuilder();

            builder.ConfigureAppConfiguration((hostingContext, config) => {
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                config.AddEnvironmentVariables();

                if(args != null)
                    config.AddCommandLine(args);

            });

            builder.ConfigureServices((hostingContext, services) => {
                services.AddAutoMapperConfiguration();

                services.AddEntityFrameworkConfiguration(hostingContext.Configuration);

                services.AddGeneralConfiguration();
                services.AddApplicationServiceConfiguration();
                services.AddDomainConfiguration();
                services.AddInfraConfiguration();
                services.AddInfraElasticSearchConfiguration();

                services.AddOptions();
                services.AddMediatR(typeof(Program));

                services.AddScoped<IHostedService, QueueManagerService>();
            });

            builder.ConfigureLogging((hostingContext, logging) => {
                logging.AddLog4Net();
            });

            await builder.RunConsoleAsync();
        }
    }
}
