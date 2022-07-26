using WeightControl.Api.Views;
using WeightControl.Domain.Entities;

namespace WeightControl.Api
{
    public static class DtoConverter
    {
        public static ProductsDto AsDto(this Product product)
        {
            return new ProductsDto()
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
