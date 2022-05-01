using WeightControl.Domain.Entities;

namespace WeightControl.BusinessLogic.Services
{
    public interface IAuthService
    {
        LoginResult Login(string login, string password, string email);
        RegisterResult Register(string name, string email, string password);
    }
}