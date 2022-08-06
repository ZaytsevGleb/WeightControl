using FluentValidation;
using WeightControl.BusinessLogic.Models;

namespace WeightControl.BusinessLogic.Validators
{
    public class ProductValidator : AbstractValidator<ProductDto>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Id > 0).NotNull().NotEmpty().WithMessage("Id is not valid");
            RuleFor(p => p.Name).NotNull().NotEmpty().Matches(@"^[a-zA-Z]+$").Length(3, 250);
            RuleFor(p => p.Calories).NotNull().InclusiveBetween(10, 4000).WithMessage("Calories is not valid");
            RuleFor(p => p.Type).InclusiveBetween(0, 8).NotNull().WithMessage("Type is not valid"); ;
            RuleFor(p => p.Unit).InclusiveBetween(0, 2).NotNull().WithMessage("Unit is not valid");
        }
    }
}
