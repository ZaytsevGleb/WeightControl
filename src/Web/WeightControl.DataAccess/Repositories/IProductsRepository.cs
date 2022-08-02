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
        List<Product> Find(Expression<Func<Product, bool>> predicate = null);
        Product Get(int id);
        Product Create(Product product);
        Product Update(Product product);
        void Delete(Product product);
    }
}
