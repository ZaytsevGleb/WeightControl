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
        private readonly ApplicationDBContext context;

        public ProductsRepository(ApplicationDBContext context)
        {
            this.context = context;
        }

        public Product Get(int id)
        {
            return context.Products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> Find(string name)
        {
            return context.Products
                .Where(p => p.Name == name)
                .ToList();
        }

        public Product Create(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }

        public Product Update(Product product)
        {
            context.Update(product);
            context.SaveChanges();
            return product;
        }

        public void Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }
    }
}
