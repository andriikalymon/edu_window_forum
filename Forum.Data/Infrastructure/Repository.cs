using Forum.Data.Context;
using Forum.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data.Infrastructure
{
    public sealed class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, IEntity
    {
        private readonly ForumContext context;
        private readonly DbSet<TEntity> dbEntities;

        public Repository(ForumContext context)
        {
            this.context = context;
            dbEntities = this.context.Set<TEntity>();
        }

        public IQueryable<TEntity> Query(params Expression<Func<TEntity, object>>[] includes)
        {
            var dbSet = context.Set<TEntity>();
            var query = includes
                .Aggregate<Expression<Func<TEntity, object>>, IQueryable<TEntity>>(dbSet, (current, include) => current.Include(include));

            return query ?? dbSet;
        }

        public ValueTask<TEntity> GetByIdAsync(params object[] keys) => dbEntities.FindAsync(keys);

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            CheckEntityForNull(entity);
            return (await dbEntities.AddAsync(entity)).Entity;
        }

        public Task AddRangeAsync(IEnumerable<TEntity> entities) => dbEntities.AddRangeAsync(entities);

        public async Task<TEntity> UpdateAsync(TEntity entity) =>
            await Task.Run(() => dbEntities.Update(entity).Entity);

        public async Task DeleteRangeAsync(IEnumerable<TEntity> entities) =>
            await Task.Run(() => dbEntities.RemoveRange(entities));

        public Task<int> SaveChangesAsync() => context.SaveChangesAsync();

        public void Delete(TEntity entity) => context.Entry(entity).State = EntityState.Deleted;

        private static void CheckEntityForNull(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity), "The entity to add cannot be null.");
            }
        }
    }
}
