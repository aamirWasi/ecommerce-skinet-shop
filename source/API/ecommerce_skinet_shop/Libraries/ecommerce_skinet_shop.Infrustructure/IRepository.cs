using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ecommerce_skinet_shop.Infrustructure
{
    public interface IRepository<TEntity, TKey, TContext>
        where TEntity : class, IEntity<TKey>
        where TContext : DbContext
    {
        Task<IReadOnlyList<TEntity>> GetAsync();
        Task<TEntity> GetByIdAsync(TKey id);
        void Add(TEntity entity);
        void Remove(TKey id);
        void Remove(TEntity entityToDelete);
        void Remove(Expression<Func<TEntity, bool>> filter);
        void Edit(TEntity entityToUpdate);
        Task<TEntity> GetEntityWithSpec(ISpecification<TEntity> spce);
        Task<IReadOnlyList<TEntity>> GetEntitiesWithSpec(ISpecification<TEntity> spce);
        Task<int> CountAsync(ISpecification<TEntity> spec);
    }
}
