using System;
using System.Threading.Tasks;
using Pets.Megastore.Auth.Api.Enums;
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
            AuthenticationType type = GetAuthType(authorization);
            if(type.Equals(AuthenticationType.BASIC))
            {
                
            }
            return null;
        }

        private AuthenticationType GetAuthType(string authorization)
        {
            if(authorization == null)
                return AuthenticationType.NONE;
            
            string type = authorization.Split(" ", StringSplitOptions.RemoveEmptyEntries)[0];

            if(type.Equals("basic", StringComparison.CurrentCultureIgnoreCase))
                return AuthenticationType.BASIC;
            
            if(type.Equals("bearer", StringComparison.CurrentCultureIgnoreCase))
                return AuthenticationType.BEARER;

            return AuthenticationType.NONE;
        }
    }
}