using FluentValidation;
using System.Collections.Generic;
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
        private readonly IJwtTokenGenerator jwtTokenGenerator;

        public AuthService(
            IRepository<User> repository,
            IValidator<LoginDto> loginValidator,
            IValidator<RegisterDto> registerValidator,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            this.repository = repository;
            this.loginValidator = loginValidator;
            this.registerValidator = registerValidator;
            this.jwtTokenGenerator = jwtTokenGenerator;
        }
        public async Task<LoginResultDto> Login(LoginDto loginDto)
        {
            var validResult = loginValidator.Validate(loginDto);
            if (!validResult.IsValid)
            {
                throw new UnauthorizedException(validResult.ToString());
            }

            var user = await repository.FirstAsync(x => x.Name == loginDto.Login);
            if (user == null)
            {
                return new LoginResultDto
                {
                    Succeded = false,
                    Error = LoginError.UserNotFound
                };
            }

            if (user.Password != loginDto.Password)
            {
                return new LoginResultDto
                {
                    Succeded = false,
                    Error = LoginError.IncorrectPassword
                };
            }

            var token = jwtTokenGenerator.GenerateToken(user.Name, user.Email, /*пока что так*/(List<Role>)user.Roles);

            return new LoginResultDto
            {
                Succeded = true,
                Token = token
            };
        }

        public async Task<RegisterResultDto> Register(RegisterDto registerDto)
        {
            var validResult = registerValidator.Validate(registerDto);
            if (!validResult.IsValid)
            {
                throw new BadRequestException(validResult.ToString());
            }

            var user = await repository.FirstAsync(x => x.Email == registerDto.Email);
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
                var registeredUser = await repository.CreateAsync(new User
                {
                    Email = registerDto.Email,
                    Name = registerDto.Name,
                    Password = registerDto.Password,
                    //разобраться с добавлением роли
                    Roles = new List<Role> { new Role { Name = "user" } }
                }); ;

                var token = jwtTokenGenerator.GenerateToken(registeredUser.Name, registeredUser.Email, /*пока что так*/(List<Role>)registeredUser.Roles);

                return new RegisterResultDto
                {
                    Succeded = true,
                    Token = token
                };
            }
        }
    }
}