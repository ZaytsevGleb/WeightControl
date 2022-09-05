using FluentValidation;
using System.Threading.Tasks;
using WeightControl.Application.Auth.Models;
using WeightControl.Application.Common.Exceptions;
using WeightControl.Application.Common.Interfaces;
using WeightControl.Application.Exceptions;
using WeightControl.Domain.Entities;
using WeightControl.Domain.Enums;

namespace WeightControl.Application.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<User> repository;
        private readonly IValidator<LoginDto> loginValidator;
        private readonly IValidator<RegisterDto> registerValidator;

        public AuthService(
            IRepository<User> repository,
            IValidator<LoginDto> loginValidator,
            IValidator<RegisterDto> registerValidator)
        {
            this.repository = repository;
            this.loginValidator = loginValidator;
            this.registerValidator = registerValidator;
        }
        public async Task<LoginResultDto> Login(LoginDto login)
        {
            var validResult = loginValidator.Validate(login);
            if (!validResult.IsValid)
            {
                throw new UnauthorizedException(validResult.ToString());
            }

            var user = await repository.FirstAsync(x => x.Login == login.Login);
            if (user == null)
            {
                return new LoginResultDto
                {
                    Succeded = false,
                    Error = LoginError.UserNotFound
                };
            }

            if (user.Password != login.Password)
            {
                return new LoginResultDto
                {
                    Succeded = false,
                    Error = LoginError.IncorrectPassword
                };
            }

            return new LoginResultDto
            {
                Succeded = true
            };
        }

        public async Task<RegisterResultDto> Register(RegisterDto register)
        {
            var validResult = registerValidator.Validate(register);
            if (!validResult.IsValid)
            {
                throw new BadRequestException(validResult.ToString());
            }

            var user = await repository.FirstAsync(x => x.Login == register.Login);
            if (user != null)
            {
                return new RegisterResultDto
                {
                    Succeded = false,
                    Error = RegisterError.SuchUserAlreadyExists
                };
            }
            else
            {
                await repository.CreateAsync(new User
                {
                    Email = register.Email,
                    Login = register.Login,
                    Password = register.Password,
                    /*Roles*/
                });

                return new RegisterResultDto
                {
                    Succeded = true,
                };
            }
        }
    }
}