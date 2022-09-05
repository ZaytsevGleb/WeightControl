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
            var loginResultDto = await authService.Login(loginDto);

            return Ok(loginResultDto);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            var registerResultDto = await authService.Register(registerDto);

            return Ok(registerResultDto);
        }
    }
}