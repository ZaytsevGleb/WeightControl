using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightControl.Domain.Entities;

namespace WeightControl.DataAccess.Repositories
{
    public interface IProductsRepository
    {
        public List<Product> Find(string name = null);
        public Product Get(int id);
        public Product Create(Product product);
        public Product Update(Product product);
        public void Delete(Product product);
    }
}
