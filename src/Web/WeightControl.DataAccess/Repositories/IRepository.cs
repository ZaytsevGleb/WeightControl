using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WeightControl.Domain.Entities;

namespace WeightControl.DataAccess.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<List<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate = null);
        Task<TEntity> GetAsync(int id);
        Task<TEntity> CreateAsync(TEntity item);
        Task<TEntity> UpdateAsync(TEntity item);
        Task DeleteAsync (TEntity item);
    }
}
