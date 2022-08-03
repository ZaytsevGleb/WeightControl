using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightControl.Domain.Entities;

namespace WeightControl.BusinessLogic.Services
{
    public static class ProductMappingService
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
