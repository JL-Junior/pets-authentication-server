using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Pets.Megastore.Auth.Api.Data;

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

            return services.AddDbContext<AppDbContext>(options => options.UseNpgsql(sb.ConnectionString));
        }
    }
}