using System.Threading.Tasks;
using Pets.Megastore.Auth.Api.Models;

namespace Pets.Megastore.Auth.Api.Services
{
    public class LoginService : ILoginService
    {
        private readonly ITokenService _tokenService;
        public LoginService(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        public Task<JwtTokenDto> GetTokenAsync(string authorization)
        {
            return null;
        }
    }
}