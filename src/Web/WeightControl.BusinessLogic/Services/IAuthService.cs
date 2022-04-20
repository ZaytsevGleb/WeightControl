using WeightControl.Domain.Entities;

namespace WeightControl.BusinessLogic.Services
{
    public interface IAuthService
    {
        LoginResult Login(string login, string pasword);
    }
}