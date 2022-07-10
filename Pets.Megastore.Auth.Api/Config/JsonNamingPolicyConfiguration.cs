using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Pets.Megastore.Auth.Api.Config
{
    public static class JsonNamingPolicyConfiguration
    {
        public static IMvcBuilder configureJsonPolicies(this IMvcBuilder services){
            return services.AddJsonOptions(configureOptions);            
        }

        private static void configureOptions(JsonOptions options)
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