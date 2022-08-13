using Microsoft.AspNetCore.Mvc;
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
        public ActionResult Login(LoginDto loginDto)
        {
            var loginResult = authService.Login(loginDto.Login, loginDto.Password, loginDto.Email);
            var loginResultDto = new LoginResultDto()
            {
                Succeded = loginResult.Succeded,
                Error = loginResult.Error
            };

            return Ok(loginResultDto);
        }

        [HttpPost("register")]
        public ActionResult Register(RegisterDto registerDto)
        {
            var registerResult = authService.Register(registerDto.Login, registerDto.Email, registerDto.Password);
            var registerResultDto = new RegisterResultDto()
            {
                Succeded = registerResult.Succeded,
                Error = registerResult.Error
            };

            return Ok(registerResultDto);
        }
    }
}