using System.Collections.Generic;
using System.Threading.Tasks;
using WeightControl.Application.Products.Models;

namespace WeightControl.Application.Products
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
