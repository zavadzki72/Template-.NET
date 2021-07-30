using DotNetTemplate.Domain.Events;
using DotNetTemplate.Domain.Interfaces.Services;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace DotNetTemplate.QueueManager.Consumers {

    public class OnTeamCreatedEventConsumer : IConsumer<TeamCreatedEvent> {

        private readonly IServiceProvider _serviceProvider;

        public OnTeamCreatedEventConsumer(IServiceProvider serviceProvider) {
            _serviceProvider = serviceProvider;
        }

        public async Task Consume(ConsumeContext<TeamCreatedEvent> context) {

            using var scope = _serviceProvider.CreateScope();

            try {
                var service = scope.ServiceProvider.GetRequiredService<ITeamEventsApplicationService>();

                await service.TeamCreated(context.Message.IdTeam);
            } catch(Exception ex) {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<OnTeamCreatedEventConsumer>>();

                logger.LogError(ex, $"OnTeamCreatedEventConsumer - Erro ao consumir a fila");
                throw;
            }

        }
    }
}
