using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<Product> GetAsync(int id)
        {
            return await context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<Product>> FindAsync(Expression<Func<Product, bool>> predicate = null)
        {
            var query = context.Products.AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Product> CreateAsync(Product product)
        {
            await context.Products.AddAsync(product);
            await context.SaveChangesAsync();
            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            context.Products.Update(product);
            await context.SaveChangesAsync();
            return product;
        }

        public async Task DeleteAsync(Product product)
        {
            context.Products.Remove(product);
            await context.SaveChangesAsync();
        }
    }
}
