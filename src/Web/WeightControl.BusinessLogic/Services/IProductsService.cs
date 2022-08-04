using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WeightControl.BusinessLogic.Mapping;
using WeightControl.BusinessLogic.Models;
using WeightControl.Domain.Entities;

namespace WeightControl.BusinessLogic.Services
{
    public interface IProductsService
    {
        ProductDto Get(int id);
        List<ProductDto> GetAll(string name);
        ProductDto Create(ProductDto product);
        ProductDto Update(int id, ProductDto product);
        void Delete(int id);
    }
}
