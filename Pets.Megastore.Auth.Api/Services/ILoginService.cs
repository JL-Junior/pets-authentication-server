using System.Threading.Tasks;
using Pets.Megastore.Auth.Api.Models;

namespace Pets.Megastore.Auth.Api.Services
{
    public interface ILoginService
    {
        Task<JwtTokenDto> GetTokenAsync(string authorization);
    }
}