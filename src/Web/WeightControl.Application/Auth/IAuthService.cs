using WeightControl.Application.Auth.Models;

namespace WeightControl.Application.Auth
{
    public interface IAuthService
    {
        LoginResultDto Login(string login, string password, string email);
        RegisterResultDto Register(string name, string email, string password);
    }
}