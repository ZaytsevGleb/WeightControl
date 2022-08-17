using FluentValidation;

namespace WeightControl.Application.Products.Models
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(p => p.Name).NotNull().NotEmpty().Matches(@"^[a-zA-Z]+$").Length(3, 250);
            RuleFor(p => p.Calories).NotNull().InclusiveBetween(10, 4000).WithMessage("Calories is not valid");
            RuleFor(p => p.Type).InclusiveBetween(0, 8).NotNull().WithMessage("Type is not valid");
            RuleFor(p => p.Unit).InclusiveBetween(0, 2).NotNull().WithMessage("Unit is not valid");
        }
    }
}
