using System.Security.Cryptography;
using System.Threading.Tasks;
using Pets.Megastore.Auth.Api.Models;

namespace Pets.Megastore.Auth.Api.Services
{
    public interface ITokenService
    {
        Task<JwtTokenDto> GetBasicToken(string user, string password);
    }
}