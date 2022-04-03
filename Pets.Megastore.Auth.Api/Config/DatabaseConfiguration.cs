using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Pets.Megastore.Auth.Api.Data;
using Pets.Megastore.Auth.Api.Utils;

namespace Pets.Megastore.Auth.Api
{
    public static class DatabaseConfiguration
    {
        public static void AddDbConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            NpgsqlConnectionStringBuilder sb = new NpgsqlConnectionStringBuilder();            
            sb.Database = configuration["API_DB_DATABASE"];
            sb.Host = configuration["API_DB_HOST"];
            sb.Port = int.Parse(configuration["API_DB_PORT"]?? DefaultUtils.API_DB_PORT);
            sb.Password = configuration["API_DB_PASSWORD"];
            sb.Username = configuration["API_DB_USERNAME"];

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(sb.ToString());
            });
        }
    }
}