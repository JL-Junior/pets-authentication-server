using System;
using System.Threading.Tasks;
using Pets.Megastore.Auth.Api.Enums;
using Pets.Megastore.Auth.Api.Models;

namespace Pets.Megastore.Auth.Api.Services{
    public class TokenService : ITokenService
    {
        public Task<JwtTokenDto> GetBasicToken(string authorization)
        {
            throw new NotImplementedException();
        }
    }
}