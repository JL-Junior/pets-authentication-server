using System.Text.Json;
using System.Threading.Tasks;

namespace Pets.Megastore.Auth.Api
{
    public static class JsonExtensions
    {
        public static string ToJson(this object obj){
            return JsonSerializer.Serialize(obj);
        }
        public static async Task<string> ToJsonAsync(this object obj)
        {
            return await Task.Run(() => ToJson(obj));
        }
    }
}