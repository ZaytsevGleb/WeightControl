using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeightControl.Application.Auth.Models;
using WeightControl.Application.Common.Interfaces;
using WeightControl.Application.Exceptions;
using WeightControl.Domain.Entities;
using WeightControl.Domain.Enums;

namespace WeightControl.Application.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IRepository<User> userRepository;
        private readonly IRepository<Role> roleRepository;
        private readonly IValidator<LoginDto> loginValidator;
        private readonly IValidator<RegisterDto> registerValidator;
        private readonly IJwtTokenGenerator jwtTokenGenerator;

        public AuthService(
            IRepository<User> userRepository,
            IRepository<Role> roleRepository,
            IValidator<LoginDto> loginValidator,
            IValidator<RegisterDto> registerValidator,
            IJwtTokenGenerator jwtTokenGenerator)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.loginValidator = loginValidator;
            this.registerValidator = registerValidator;
            this.jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<LoginResultDto> LoginAsync(LoginDto loginDto)
        {
            var validResult = loginValidator.Validate(loginDto);
            if (!validResult.IsValid)
            {
                throw new BadRequestException(validResult.ToString());
            }

            var user = await userRepository.FirstAsync(
                x => x.Email == loginDto.Email,
                x => x.Include(x => x.Roles));

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

            var token = jwtTokenGenerator.GenerateToken(user);

            return new LoginResultDto
            {
                Succeded = true,
                Token = token
            };
        }

        public async Task<RegisterResultDto> RegisterAsync(RegisterDto registerDto)
        {
            var validResult = registerValidator.Validate(registerDto);
            if (!validResult.IsValid)
            {
                throw new BadRequestException(validResult.ToString());
            }

            var user = await userRepository.FirstAsync(x => x.Email == registerDto.Email);
            if (user != null)
            {
                return new RegisterResultDto
                {
                    Succeded = false,
                    Error = RegisterError.SuchUserAlreadyExists
                };
            }

            var userRole = await roleRepository.FirstAsync(x => x.Name == "user");

            user = new User
            {
                Email = registerDto.Email,
                Name = registerDto.Name,
                Password = registerDto.Password,
                Roles = new List<Role> { userRole }
            };

            await userRepository.CreateAsync(user);

            var token = jwtTokenGenerator.GenerateToken(user);

            return new RegisterResultDto
            {
                Succeded = true,
                Token = token
            };
        }
    }
}