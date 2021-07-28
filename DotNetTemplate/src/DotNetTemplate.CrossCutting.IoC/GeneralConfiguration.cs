using DotNetTemplate.CrossCutting.Bus;
using DotNetTemplate.Domain.Core.Bus;
using DotNetTemplate.Domain.Core.Handlers;
using DotNetTemplate.Domain.Core.Models;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetTemplate.CrossCutting.IoC {

    public static class GeneralConfiguration {

        public static void AddApplicationServiceConfiguration(this IServiceCollection services) {
        }

        public static void AddDomainConfiguration(this IServiceCollection services) {
        }

        public static void AddInfraConfiguration(this IServiceCollection services) {
        }

        public static void AddGeneralConfiguration(this IServiceCollection services) {

            //Bus
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            //Notification
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        }

    }
}
