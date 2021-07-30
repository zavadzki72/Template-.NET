using DotNetTemplate.Infra.PostgreSql.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetTemplate.CrossCutting.IoC {

    public static class EntityFrameworkConfiguration {

        public static void AddEntityFrameworkConfiguration(this IServiceCollection services, IConfiguration configuration) {

            var connectionString = configuration.GetConnectionString("PostgreSqlConnection");

            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseNpgsql(connectionString);
            }, ServiceLifetime.Scoped);

        }

    }
}
