using Microsoft.Extensions.DependencyInjection;
using Pets.Megastore.Auth.Api.Services;

namespace Pets.Megastore.Auth.Api
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServicesConfiguration(this IServiceCollection services)
        {
            return services
                .AddScoped<ILoginService, LoginService>()
                .AddScoped<ITokenService, TokenService>();
        }
    }
}