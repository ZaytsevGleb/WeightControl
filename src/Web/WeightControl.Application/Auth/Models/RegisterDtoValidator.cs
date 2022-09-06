using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightControl.Domain.Enums;

namespace WeightControl.Application.Auth.Models
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(r => r.Name).NotNull().NotEmpty().WithMessage(RegisterError.NameIsNullOrEmpty.ToString());
            RuleFor(r => r.Password).NotNull().NotEmpty().WithMessage(RegisterError.PasswordIsNullOrEmpty.ToString());
            RuleFor(r =>r.Email).NotNull().NotEmpty().WithMessage(RegisterError.EmailIsNullOrEmpty.ToString());
        }
    }
}
