using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ecommerce_skinet_shop.Infrustructure
{
    public abstract class Repository<TEntity, TKey, TContext>
        : IRepository<TEntity, TKey, TContext>
        where TEntity : class, IEntity<TKey>
        where TContext : DbContext
    {
        protected TContext _dbContext;
        protected DbSet<TEntity> _dbSet;
        protected int CommandTimeout { get; set; }

        public Repository(TContext context)
        {
            CommandTimeout = 300;
            _dbContext = context;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public virtual async Task<IReadOnlyList<TEntity>> GetAsync()
        {
            IQueryable<TEntity> query = _dbSet;
            return await query.ToListAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(TKey id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Remove(TKey id)
        {
            var entityToDelete = _dbSet.Find(id);
            Remove(entityToDelete);
        }

        public virtual void Remove(TEntity entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }

        public virtual void Remove(Expression<Func<TEntity, bool>> filter)
        {
            _dbSet.RemoveRange(_dbSet.Where(filter));
        }

        public virtual void Edit(TEntity entityToUpdate)
        {
            _dbSet.Attach(entityToUpdate);
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public async Task<TEntity> GetEntityWithSpec(ISpecification<TEntity> spce)
        {
            return await ApplySpecification(spce).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetEntitiesWithSpec(ISpecification<TEntity> spce)
        {
            return await ApplySpecification(spce).ToListAsync();
        }

        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> spec)
        {
            return SpecificationEvalator<TEntity>.GetQuery(_dbSet.AsQueryable(), spec);
        }

        public async Task<int> CountAsync(ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }
    }
}
