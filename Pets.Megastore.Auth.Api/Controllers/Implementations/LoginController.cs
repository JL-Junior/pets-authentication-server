using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pets.Megastore.Auth.Api.Controllers.Apis;
using Pets.Megastore.Auth.Api.Models;
using Pets.Megastore.Auth.Api.Repositories;
using Pets.Megastore.Auth.Api.Services;

namespace Pets.Megastore.Auth.Api.Controllers
{
    public class LoginController : LoginApi
    {
        private readonly IUserRepository _repo;
        private readonly ILoginService _loginService;

        public LoginController(ILogger<LoginApi> logger, ILoginService loginService) : base(logger)
        {
            _loginService = loginService;
        }

        public override async Task<ActionResult<JwtTokenDto>> Signin(string authorization)
        {
            _logger.LogDebug("Calling login route:", authorization);
            return Ok(await _loginService.GetTokenAsync(authorization));            
        }

        public override Task<ActionResult<JwtTokenDto>> Signup([FromBody] string body)
        {
            throw new NotImplementedException();
        }
    }
}