namespace Pets.Megastore.Auth.Api.Models
{
    public class JwtTokenDto
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public int expiresInHours { get; set; }
    }
}