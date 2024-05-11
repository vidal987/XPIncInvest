using Microsoft.EntityFrameworkCore;
using XPIncInvest.Domain.Abstractions;
using XPIncInvest.Domain.Primitives;

namespace XPIncInvest.Infrastructure.Context
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected readonly DataContext Context;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(DataContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }


        public IUnitOfWork UnitOfWork => Context;

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual async Task<TEntity> GetByIdAsync<TId>(TId id)
        {
            return await DbSet.FindAsync(id).ConfigureAwait(false);
        }

        public virtual void Update(TEntity entity)
        {
            DbSet.Update(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            DbSet.Remove(entity);
        }
    }
}
