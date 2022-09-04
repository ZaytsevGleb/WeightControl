using FluentValidation;
using System.Threading.Tasks;
using WeightControl.Application.Auth.Models;
using WeightControl.Application.Common.Exceptions;
using WeightControl.Application.Common.Interfaces;
using WeightControl.Application.Exceptions;
using WeightControl.Domain.Entities;

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
           
        }

        public async Task<RegisterResultDto> Register(RegisterDto register)
        {
            var validResult = registerValidator.Validate(register);
            if (!validResult.IsValid)
            {
                throw new BadRequestException(validResult.ToString());
            }

        }
    }
}