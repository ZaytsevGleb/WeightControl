using FluentValidation;
using WeightControl.Domain.Enums;

namespace WeightControl.Application.Auth.Models
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(r => r.Name).NotNull().NotEmpty();
            RuleFor(r => r.Password).NotNull().NotEmpty();
            RuleFor(r => r.Email).NotNull().NotEmpty().WithMessage(RegisterError.EmailIsNullOrEmpty.ToString());
        }
    }
}
