using WeightControl.Api.Views;
using WeightControl.Domain.Entities;

namespace WeightControl.Api
{
    public static class DtoConverter
    {
        public static ProductDto AsDto(this Product product)
        {
            return new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Calories = product.Calories,
                Type = product.Type,
                Unit = product.Unit
            };
        }
    }
}
