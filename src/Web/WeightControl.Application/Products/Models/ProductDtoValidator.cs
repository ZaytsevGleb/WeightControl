using FluentValidation;

namespace WeightControl.Application.Products.Models
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {   
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Calories).NotEmpty();
            RuleFor(p => p.Type).NotEmpty();
            RuleFor(p => p.Unit).NotEmpty();
        }
    }
}
