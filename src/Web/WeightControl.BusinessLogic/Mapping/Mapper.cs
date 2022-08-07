using System.Collections.Generic;
using System.Threading.Tasks;
using WeightControl.BusinessLogic.Models;
using WeightControl.Domain.Entities;

namespace WeightControl.BusinessLogic.Mapping
{
    public static class Mapper
    {
        public static ProductDto AsProductDto(this Product product)
        {
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Calories = product.Calories,
                Type = product.Type,
                Unit = product.Unit
            };
        }
        public static List<ProductDto> AsProductDto(this List<Product> products)
        {
            List<ProductDto> result = new List<ProductDto>();
            foreach (var p in products)
            {
                result.Add(new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Calories = p.Calories,
                    Type = p.Type,
                    Unit = p.Unit
                });
            }
            return result;
        }
        public static Product AsProduct(this ProductDto productDto)
        {
            return new Product
            {
                Id = productDto.Id,
                Name = productDto.Name,
                Calories = productDto.Calories,
                Type = productDto.Type,
                Unit = productDto.Unit
            };
        }

        public static Product AsProductCreate(this ProductDto productDtoCreate)
        {
            return new Product
            {
                Name = productDtoCreate.Name,
                Calories = productDtoCreate.Calories,
                Type = productDtoCreate.Type,
                Unit = productDtoCreate.Unit
            };
        }
    }
}
