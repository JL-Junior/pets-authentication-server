using System;
using System.Threading.Tasks;
using Pets.Megastore.Auth.Api.Enums;
using Pets.Megastore.Auth.Api.Exceptions;
using Pets.Megastore.Auth.Api.Models;
using Pets.Megastore.Auth.Api.Utils;

namespace Pets.Megastore.Auth.Api.Services
{
    public class LoginService : ILoginService
    {
        private readonly ITokenService _tokenService;
        public LoginService(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        
        public async Task<JwtTokenDto> GetTokenAsync(string authorization)        {
            AuthenticationType type = GetAuthType(authorization);
            if(!type.Equals(AuthenticationType.BASIC)) throw RestException.Unauthorized(MessagesUtils.NOT_VALID_AUTH_TYPE);
            
            return await _tokenService.GetBasicToken(authorization);
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