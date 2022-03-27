using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Authentication.Controllers
{
    [ApiController]
    [Route("/hello")]
    public class HelloTestController : ControllerBase
    {
        private const string MESSAGE = "Hello my friend";

        private readonly ILogger<HelloTestController> _logger;

        public HelloTestController(ILogger<HelloTestController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<string>> Get()
        {
            return await Task.Run(() => Ok(MESSAGE));
        }
    }
}
