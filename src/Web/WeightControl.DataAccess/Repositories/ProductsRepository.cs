using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeightControl.Domain.Entities;

namespace WeightControl.DataAccess.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private ApplicationDBContext Context { get; set; }

        public ProductsRepository(ApplicationDBContext context)
        {
            Context = context;
        }

        public Product Create(Product product)
        {
            Context.Set<Product>().Add(product);
            Context.SaveChanges();
            return product;
        }

        public void Delete(int id)
        {
            var toDelete = Context.Set<Product>().FirstOrDefault(p => p.Id == id);
            Context.Set<Product>().Remove(toDelete);
            Context.SaveChanges();
        }

        public Product Get(int id)
        {
            return Context.Set<Product>().FirstOrDefault(p => p.Id == id);

        }

        public List<Product> GetAll()
        {
            return Context.Set<Product>().ToList();
        }

        public Product Update(Product product)
        {
            var toUpdate = Context.Set<Product>().FirstOrDefault(p => p.Id == product.Id);
            if (toUpdate != null)
                toUpdate = product;

            Context.Update(toUpdate);
            Context.SaveChanges();
            return toUpdate;
        }
    }
}
