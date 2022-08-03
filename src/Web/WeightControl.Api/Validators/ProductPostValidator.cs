using FluentValidation;
using WeightControl.Api.Views;
using WeightControl.BusinessLogic.Exceptions;

namespace WeightControl.BusinessLogic.Validators
{
    public class ProductPostValidator : AbstractValidator<ProductDto>
    {
        public ProductPostValidator()
        {
            RuleFor(p => p.Id > 0).NotNull().NotEmpty().WithMessage("Id is not valid");
            RuleFor(p => p.Name).NotNull().NotEmpty().Matches(@"^[a-zA-Z]+$").Length(3,250);
            RuleFor(p => p.Calories).NotNull().InclusiveBetween(10, 4000);
            RuleFor(p => p.Type).InclusiveBetween(0, 6).NotNull();
            RuleFor(p => p.Unit).InclusiveBetween(0, 2).NotNull();
        }
    }
}
