using FluentValidation;

namespace WeightControl.Application.Auth.Models
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        {
            RuleFor(l => l.Login).NotNull().NotEmpty();
            RuleFor(l => l.Password).NotNull().NotEmpty();
        }
    }
}