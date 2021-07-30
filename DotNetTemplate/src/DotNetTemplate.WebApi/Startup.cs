using DotNetTemplate.CrossCutting.IoC;
using DotNetTemplate.WebApi.Configurations;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text.Json.Serialization;

namespace DotNetTemplate.WebApi {

    public class Startup {
        
        public IConfiguration Configuration { get; }
    
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services) {

            //Converter enumeradores em string para documentação
            services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

            services.AddSwaggerConfiguration();
            services.AddMediatR(typeof(Startup));

            services.AddAutoMapperConfiguration();

            services.AddEntityFrameworkConfiguration(Configuration);

            services.AddMassTransitConfiguration(Configuration);

            services.AddGeneralConfiguration();
            services.AddApplicationServiceConfiguration();
            services.AddDomainConfiguration();
            services.AddInfraConfiguration();
            services.AddInfraElasticSearchConfiguration();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {

            if(env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwaggerSetup();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
