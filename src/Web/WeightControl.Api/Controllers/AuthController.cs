using Microsoft.AspNetCore.Mvc;
using WeightControl.Api.Models;
using WeightControl.BusinessLogic.Services;


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
            var loginResult = authService.Login(loginDto.Login,loginDto.Password);
            var loginResultDto = new LoginResultDto()
            {
                Succeded = loginResult.Succeded,
                Error = loginResult.Error
            };
            return Ok(loginResultDto);
        }
    }
}