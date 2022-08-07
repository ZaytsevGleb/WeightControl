using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WeightControl.Domain.Entities;

namespace WeightControl.DataAccess.Repositories
{
    public interface IProductsRepository
    {
        Task<List<Product>> FindAsync(Expression<Func<Product, bool>> predicate = null);
        Task<Product> GetAsync(int id);
        Task<Product> CreateAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task DeleteAsync (Product product);
    }
}
