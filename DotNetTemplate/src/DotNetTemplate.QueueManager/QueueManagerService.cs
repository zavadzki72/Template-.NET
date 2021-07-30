using DotNetTemplate.QueueManager.Consumers;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace DotNetTemplate.QueueManager {

    public class QueueManagerService : IHostedService {

        private IBusControl _busControl;

        private readonly IServiceProvider _serviceProvider;
        private readonly IConfiguration _configuration;

        public QueueManagerService(IServiceProvider serviceProvider, IConfiguration configuration) {
            _serviceProvider = serviceProvider;
            _configuration = configuration;
        }

        public async Task StartAsync(CancellationToken cancellationToken) {

            _busControl = Bus.Factory.CreateUsingRabbitMq(cfg => {

                var connString = _configuration.GetConnectionString("RabbitMqConnection");

                cfg.Host(connString);

                cfg.ReceiveEndpoint("on-team-created", e => {
                    e.Consumer(() => new OnTeamCreatedEventConsumer(_serviceProvider));
                });
            });

            var source = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            await _busControl.StartAsync(source.Token);
        }

        public async Task StopAsync(CancellationToken cancellationToken) {
            await _busControl.StopAsync(cancellationToken);
        }

    }
}
