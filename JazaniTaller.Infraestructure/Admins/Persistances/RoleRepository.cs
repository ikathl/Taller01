using JazaniTaller.Domain.Admins.Models;
using JazaniTaller.Domain.Admins.Repositores;
using JazaniTaller.Infraestructure.Cores.Contexts;
using Microsoft.EntityFrameworkCore;

namespace JazaniTaller.Infraestructure.Admins.Persistances
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public RoleRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IReadOnlyList<Role>> FindAllAsync()
        {
            return await _dbContext.Roles.ToListAsync();
        }

        public async Task<Role?> FindByIdAsync(int id)
        {
            return await _dbContext.Roles.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Role?> SaveAsync(Role role)
        {
            EntityState state = _dbContext.Entry(role).State;
            _ = state switch
            {
                EntityState.Detached => _dbContext.Roles.Add(role),
                EntityState.Modified => _dbContext.Roles.Update(role),
            };

            await _dbContext.SaveChangesAsync();

            return role;

        }
    }
}
