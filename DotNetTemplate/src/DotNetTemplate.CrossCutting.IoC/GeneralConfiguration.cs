using DotNetTemplate.ApplicationService;
using DotNetTemplate.CrossCutting.Bus;
using DotNetTemplate.Domain;
using DotNetTemplate.Domain.CommandHandlers;
using DotNetTemplate.Domain.Commands.Team;
using DotNetTemplate.Domain.Core.Bus;
using DotNetTemplate.Domain.Core.Handlers;
using DotNetTemplate.Domain.Interfaces.ElasticSearch;
using DotNetTemplate.Domain.Interfaces.Repositories;
using DotNetTemplate.Domain.Interfaces.Services;
using DotNetTemplate.Domain.Model;
using DotNetTemplate.Infra.ElasticSearch.Queries;
using DotNetTemplate.Infra.PostgreSql.Repositories;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetTemplate.CrossCutting.IoC {

    public static class GeneralConfiguration {

        public static void AddApplicationServiceConfiguration(this IServiceCollection services) {
            services.AddScoped<ITeamApplicationService, TeamApplicationService>();
            services.AddScoped<ITeamEventsApplicationService, TeamEventsApplicationService>();
        }

        public static void AddDomainConfiguration(this IServiceCollection services) {
            services.AddScoped<IRequestHandler<RegisterTeamCommand, Team>, TeamCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateTeamCommand, Team>, TeamCommandHandler>();
        }

        public static void AddInfraConfiguration(this IServiceCollection services) {
            services.AddScoped<ITeamRepository, TeamRepository>();
        }

        public static void AddInfraElasticSearchConfiguration(this IServiceCollection services) {
            services.AddScoped<ITeamQuery, TeamQuery>();
        }

        public static void AddGeneralConfiguration(this IServiceCollection services) {

            //Bus
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            //Notification
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        }

    }
}
