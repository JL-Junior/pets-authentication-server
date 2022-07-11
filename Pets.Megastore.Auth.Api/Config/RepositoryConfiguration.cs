using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Pets.Megastore.Auth.Api.Repositories;

namespace Pets.Megastore.Auth.Api
{
    public static class RepositoryConfiguration
    {
        public static IServiceCollection AddRepositoriesConfiguration(this IServiceCollection services){
            return services.AddScoped<IUserRepository,UserRepository>();
        }
    }
}