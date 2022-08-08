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
        Task<ProductDto> GetAsync(int id);
        Task<List<ProductDto>> FindAsync(string name);
        Task<ProductDto> CreateAsync(ProductDto product);
        Task<ProductDto> UpdateAsync(ProductDto product);
        Task DeleteAsync(int id);
    }
}
