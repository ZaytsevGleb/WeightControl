using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WeightControl.Domain.Entities;

namespace WeightControl.Application.Common.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate = null);
        Task<TEntity> GetAsync(int id);
        Task<TEntity> CreateAsync(TEntity item);
        Task<TEntity> UpdateAsync(TEntity item);
        Task DeleteAsync(TEntity item);
    }
}
