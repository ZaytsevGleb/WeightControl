using FluentValidation;
using WeightControl.Application.Auth.Models;

namespace WeightControl.Application.Auth.Validators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(l => l.Email).NotEmpty();
            RuleFor(l => l.Password).NotEmpty();
        }
    }
}