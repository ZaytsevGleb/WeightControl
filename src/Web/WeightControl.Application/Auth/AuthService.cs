using System.Diagnostics;
using WeightControl.Domain.Entities;
using WeightControl.Domain.Enums;
using WeightControl.Application.Common.Interfaces;
using WeightControl.Application.Auth.Models;

namespace WeightControl.Application.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUsersRepository usersRepository;

        public AuthService(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }
        public LoginResultDto Login(string login, string password, string email)
        {
            var user = usersRepository.GetByLogin(login);
            if (user == null)
            {
                return new LoginResultDto()
                {
                    Succeded = false,
                    Error = LoginError.UserNotFound
                };
            }

            if (user.Password != password)
            {
                return new LoginResultDto()
                {
                    Succeded = false,
                    Error = LoginError.IncorrectPassword
                };
            }

            return new LoginResultDto()
            {
                Succeded = true
            };
        }

        public RegisterResultDto Register(string login, string email, string password)
        {
            if (string.IsNullOrEmpty(login) && string.IsNullOrEmpty(email) && string.IsNullOrEmpty(password))
            {
                return new RegisterResultDto()
                {
                    Succeded = false,
                    Error = RegisterError.AllFieldsAreNullOrEmpty
                };
            }

            if (string.IsNullOrEmpty(password))
            {
                return new RegisterResultDto()
                {
                    Succeded = false,
                    Error = RegisterError.PasswordIsNullOrEmpty
                };
            }

            if (string.IsNullOrEmpty(email))
            {
                return new RegisterResultDto()
                {
                    Succeded = false,
                    Error = RegisterError.EmailIsNullOrEmpty
                };
            }

            if (string.IsNullOrEmpty(login))
            {
                return new RegisterResultDto()
                {
                    Succeded = false,
                    Error = RegisterError.LoginIsNullOrEmpty
                };
            }

            var user = usersRepository.GetByLogin(login);
            if (user != null)
            {
                return new RegisterResultDto()
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

            return new RegisterResultDto()
            {
                Succeded = true
            };
        }
    }
}