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

        public RegisterResult Register(string login, string email, string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return new RegisterResult()
                {
                    Succeded = false,
                    Error = RegisterError.PasswordIsNullOrEmpty
                };
            }
            
            if (string.IsNullOrEmpty(email))
            {
                return new RegisterResult()
                {
                    Succeded = false,
                    Error = RegisterError.EmailIsNullOrEmpty
                };
            }
            
            if (string.IsNullOrEmpty(login))
            {
                return new RegisterResult()
                {
                    Succeded = false,
                    Error = RegisterError.LoginIsNullOrEmpty
                };
            }
            
            var user = usersRepository.GetByLogin(login);
            if (user != null)
            {
                return new RegisterResult()
                {
                    Succeded = false,
                    Error = RegisterError.SuchUserAlreadyExists
                };
            }

            user = new User()
            {
                Login = login,
                Password = password,
                Email = email
            };
            usersRepository.Create(user);
            
            return new RegisterResult()
            {
                Succeded = true
            };
        }
    }
}