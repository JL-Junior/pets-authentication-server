using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pets.Megastore.Auth.Api.Models;

namespace Pets.Megastore.Auth.Api.Controllers.Apis
{
    public abstract class LoginApi : ControllerBase
    {
        protected readonly ILogger<LoginApi> _logger;
        public LoginApi(ILogger<LoginApi> logger)
        {
            _logger = logger;
            logger.Log(LogLevel.Debug, "Logando", "Logando denovo");
        }

        [HttpGet("/login")]
        [ProducesResponseType(typeof(JwtTokenDto), 200)]
        [ProducesResponseType(typeof(ErrorResponseDto), 401)]
        public abstract Task<ActionResult<JwtTokenDto>> Login([FromHeader(Name = "authorization")] string authorization);        
    }
}