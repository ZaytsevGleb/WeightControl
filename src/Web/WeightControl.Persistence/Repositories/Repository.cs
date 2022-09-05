using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WeightControl.Application.Common.Interfaces;
using WeightControl.Domain.Entities;

namespace WeightControl.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDBContext context;
        private readonly DbSet<TEntity> entities;

        public Repository(ApplicationDBContext context)
        {
            this.context = context;
            entities = context.Set<TEntity>();
        }

        public async Task<TEntity> GetAsync(int id)
        {
            return await entities
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            var query = entities.AsQueryable();
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            return await query
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TEntity> FirstAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        {
            var query = entities.AsQueryable();
            query = query.Where(predicate);
            if (include != null)
            {
                query = include.Invoke(query);
            }
            return await query
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
        }

        public async Task<TEntity> CreateAsync(TEntity item)
        {
            await entities.AddAsync(item);
            await context.SaveChangesAsync();

            return item;
        }

        public async Task<TEntity> UpdateAsync(TEntity item)
        {
            entities.Update(item);
            await context.SaveChangesAsync();

            return item;
        }

        public async Task DeleteAsync(TEntity item)
        {
            entities.Remove(item);
            await context.SaveChangesAsync();
        }
    }
}
