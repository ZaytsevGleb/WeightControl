using WeightControl.Domain.Entities;

namespace WeightControl.BusinessLogic.Services
{
    public interface IAuthService
    {
        LoginResult Login(string login, string password);
        RegisterResult Register(string name, string email, string password);
    }
}