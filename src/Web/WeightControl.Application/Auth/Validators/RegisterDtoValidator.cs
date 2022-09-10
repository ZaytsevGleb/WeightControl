using FluentValidation;
using WeightControl.Application.Auth.Models;

namespace WeightControl.Application.Auth.Validators
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(r => r.Name).NotEmpty();
            RuleFor(r => r.Password).NotEmpty();
            RuleFor(r => r.Email).NotEmpty();
        }
    }
}
