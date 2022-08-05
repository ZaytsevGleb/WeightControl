using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
            return context.Products
                .AsNoTracking()
                .FirstOrDefault(p => p.Id == id); 
        }

        public List<Product> Find(Expression<Func<Product, bool>> predicate = null)
        {
            var query = context.Products.AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return query
                .AsNoTracking()
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
            context.Products.Update(product);
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
