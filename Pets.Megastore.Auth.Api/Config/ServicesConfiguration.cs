using Microsoft.Extensions.DependencyInjection;
using Pets.Megastore.Auth.Api.Services;

namespace Pets.Megastore.Auth.Api
{
    public static class ServicesConfiguration
    {
        public static void AddServicesConfiguration(this IServiceCollection services)
        {
            services.AddScoped<ILoginService, LoginService>();
        }
    }
}