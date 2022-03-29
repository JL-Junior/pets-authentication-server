using System;
using Microsoft.Extensions.Logging;
using Moq;
using Pets.Megastore.Auth.Api.Controllers;
using Pets.Megastore.Auth.Api.Services;
using Xunit;

namespace Pets.Megastore.Auth.Tests
{
    public class LoginControllertest
    {
        private readonly Mock<ILoginService> _mockService;
        private readonly ILogger<LoginController> _logger;
        private LoginController _sut;
        
        public LoginControllerTest()
        {
            _mockService = new Mock<ILoginService>();
            _logger = LoggerFactory.Create(config => {}).CreateLogger<LoginController>();
            _sut = new LoginController(_logger, _mockService.Object);
        }

        [Fact]
        void Login_When_Authorization_Not_Basic_Throw_Error()
        {
            Assert.ThrowsAsync<NotImplementedException>(() => _sut.Login("auth"));
        }
    }
}
