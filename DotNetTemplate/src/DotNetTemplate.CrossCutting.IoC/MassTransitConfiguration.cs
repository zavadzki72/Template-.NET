using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetTemplate.CrossCutting.IoC {

    public static class MassTransitConfiguration {

        public static void AddMassTransitConfiguration(this IServiceCollection services, IConfiguration configuration) {

            services.AddMassTransit(x => {
                x.UsingRabbitMq((context, cfg) => {

                    var connString = configuration.GetConnectionString("RabbitMqConnection");

                    cfg.Host(connString);
                });
            });

            services.AddMassTransitHostedService();
        }

    }
}
