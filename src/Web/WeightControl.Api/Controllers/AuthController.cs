using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeightControl.Application.Auth;
using WeightControl.Application.Auth.Models;
using WeightControl.Application.Common.Models;

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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResultDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDto))]
        public async Task<ActionResult> LoginAsync(LoginDto loginDto)
        {
            var loginResultDto = await authService.LoginAsync(loginDto);
            return Ok(loginResultDto);
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RegisterResultDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDto))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDto))]
        public async Task<ActionResult> RegisterAsync(RegisterDto registerDto)
        {
            var registerResultDto = await authService.RegisterAsync(registerDto);
            return Ok(registerResultDto);
        }
    }
}