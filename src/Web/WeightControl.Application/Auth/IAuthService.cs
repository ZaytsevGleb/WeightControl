using System.Threading.Tasks;
using WeightControl.Application.Auth.Models;

namespace WeightControl.Application.Auth
{
    public interface IAuthService
    {
        Task<LoginResultDto> LoginAsync(LoginDto loginDto);
        Task<RegisterResultDto> RegisterAsync(RegisterDto registerDto);
    }
}