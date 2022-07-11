using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Pets.Megastore.Auth.Api.Data;
using Pets.Megastore.Auth.Api.Data.Configuration;
using Pets.Megastore.Auth.Api.Data.Entities;

namespace Pets.Megastore.Auth.Api
{
    public static class DatabaseConfiguration
    {
        public static IServiceCollection AddDbConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            NpgsqlConnectionStringBuilder sb = new NpgsqlConnectionStringBuilder();     
            sb.Database = configuration["AUTH_API_DB_DATABASE"];
            sb.Host = configuration["AUTH_API_DB_HOST"];
            sb.Port = int.Parse(configuration["AUTH_API_DB_PORT"]);
            sb.Password = configuration["AUTH_API_DB_PASSWORD"];
            sb.Username = configuration["AUTH_API_DB_USER"];

            return services
                .AddScoped<IEntityTypeConfiguration<BaseEntity>, BaseEntityConfiguration>()
                .AddScoped<IEntityTypeConfiguration<User>, UserEntityConfiguration>()
                .AddDbContext<AppDbContext>(
                    options => options.UseNpgsql(sb.ConnectionString));
        }
    }
}