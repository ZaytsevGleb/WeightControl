using FluentValidation;

namespace WeightControl.Application.Products.Models
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            var message = "Error in field: {PropertyName}, value: '{PropertyValue}'";
            
            RuleFor(p => p.Name).NotEmpty().WithMessage(message);
            RuleFor(p => p.Calories).NotEmpty().WithMessage(message);
            RuleFor(p => p.Type).NotEmpty().WithMessage(message);
            RuleFor(p => p.Unit).NotEmpty().WithMessage(message);
        }
    }
}
