using System.Threading.Tasks;
using Pets.Megastore.Auth.Api.Models;

namespace Pets.Megastore.Auth.Api.Services
{
    public class LoginService : ILoginService
    {
        public Task<JwtTokenDto> GetTokenAsync(string authorization)
        {
            throw new System.NotImplementedException();
        }
    }
}