using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pets.Megastore.Auth.Api.Data.Configuration;
using Pets.Megastore.Auth.Api.Data.Entities;

namespace Pets.Megastore.Auth.Api
{
    public static class DatabaseConfiguration
    {
        public static void AddDbConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IEntityTypeConfiguration<BaseEntity>, BaseEntityConfiguration>();
            services.AddScoped<IEntityTypeConfiguration<User>, UserEntityConfiguration>();
        }
    }
}