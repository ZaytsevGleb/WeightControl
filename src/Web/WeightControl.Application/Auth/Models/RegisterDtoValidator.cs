using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeightControl.Application.Auth.Models
{
    public class RegisterDtoValidator : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidator()
        {
            RuleFor(r => r.Login).NotNull().NotEmpty();
            RuleFor(r => r.Password).NotNull().NotEmpty();
            RuleFor(r =>r.Email).NotNull().NotEmpty();
        }
    }
}
