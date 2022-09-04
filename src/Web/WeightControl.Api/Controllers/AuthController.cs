using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeightControl.Application.Auth;
using WeightControl.Application.Auth.Models;

namespace WeightControl.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            var loginResult = await authService.Login(loginDto);
            var loginResultDto = new LoginResultDto()
            {
                Succeded = loginResult.Succeded,
                Error = loginResult.Error
            };

            return Ok(loginResultDto);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            var registerResult = await authService.Register(registerDto);
            var registerResultDto = new RegisterResultDto()
            {
                Succeded = registerResult.Succeded,
                Error = registerResult.Error
            };

            return Ok(registerResultDto);
        }
    }
}