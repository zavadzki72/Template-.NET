using AutoMapper;
using DotNetTemplate.CrossCutting.AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetTemplate.CrossCutting.IoC {

    public static class AutoMapperConfiguration {

        public static void AddAutoMapperConfiguration(this IServiceCollection services) {

            var config = AutoMapperConfig.RegisterMappings();
            config.AssertConfigurationIsValid();
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

    }
}
