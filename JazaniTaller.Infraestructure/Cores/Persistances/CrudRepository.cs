using JazaniTaller.Domain.Cores.Repositories;
using JazaniTaller.Infraestructure.Cores.Contexts;
using Microsoft.EntityFrameworkCore;

namespace JazaniTaller.Infraestructure.Cores.Persistances
{
    public abstract class CrudRepository<T, ID> : ICrudRepository<T, ID> where T : class
    {
        private readonly ApplicationDbContext context;

        protected CrudRepository(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }

        public virtual async Task<IReadOnlyList<T>> FindAllAsync()
        {
            return await context.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<T?> FindByIdAsync(ID id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> SaveAsync(T entity)
        {
            EntityState state = context.Entry(entity).State;
            _ = state switch
            {
                EntityState.Detached => context.Set<T>().Add(entity),
                EntityState.Modified => context.Set<T>().Update(entity)
            };
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
