using System.Threading.Tasks;
using WeightControl.Application.Auth.Models;

namespace WeightControl.Application.Auth
{
    public interface IAuthService
    {
        Task<LoginResultDto> Login(LoginDto loginDto);
        Task<RegisterResultDto> Register(RegisterDto registerDto);
    }
}