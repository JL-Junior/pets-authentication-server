using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Pets.Megastore.Auth.Api
{
    public static class ControllerAndJsonConfiguration
    {
        public static IServiceCollection ConfigureControllersAndJsonSettings(this IServiceCollection services){
            return services
                .AddControllers()
                .AddJsonOptions(ConfigureOptions)
                .Services;            
        }

        private static void ConfigureOptions(JsonOptions options)
        {
            var serializerOptions = options.JsonSerializerOptions;
            serializerOptions.PropertyNamingPolicy = SnakeCaseJsonPolicy.Instance;
        }
    }
    class SnakeCaseJsonPolicy : JsonNamingPolicy
    {
        public static SnakeCaseJsonPolicy Instance {get;} = new SnakeCaseJsonPolicy();

        public override string ConvertName(string name)
        {
            return string.Concat(
                name.Select((x, i) => i > 0 && char.IsUpper(x) 
                ? "_" + x.ToString() 
                : x.ToString())).ToLower();
        }
    }
}