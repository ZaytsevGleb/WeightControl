using WeightControl.DataAccess.Repositories;
using WeightControl.Domain.Entities;
using WeightControl.Domain.Enums;

namespace WeightControl.BusinessLogic.Services
{
    public class AuthService: IAuthService
    {
        private readonly IUsersRepository usersRepository;

        public AuthService(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }
        public LoginResult Login(string login, string password)
        {
            var user = usersRepository.GetByLogin(login);
            if (user == null)
            {
                return new LoginResult()
                {
                    Succeded = false,
                    Error = LoginError.UserNotFound
                };
            }

            if (user.Password != password)
            {
                return new LoginResult()
                {
                    Succeded = false,
                    Error = LoginError.IncorrectPassword
                };
            }

            return new LoginResult()
            {
                Succeded = true
            };
        }
    }
}