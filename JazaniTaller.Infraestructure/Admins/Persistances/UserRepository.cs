using JazaniTaller.Domain.Admins.Models;
using JazaniTaller.Domain.Admins.Repositores;
using JazaniTaller.Infraestructure.Cores.Contexts;
using JazaniTaller.Infraestructure.Cores.Persistances;
using Microsoft.EntityFrameworkCore;

namespace JazaniTaller.Infraestructure.Admins.Persistances
{
    public class UserRepository : CrudRepository<User, int>, IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> FindByEmailAsync(string email)
        {
            return await _dbContext.Set<User>()
                .Where(t => t.Email.ToUpper().Equals(email.ToUpper()))
                .FirstOrDefaultAsync();
        }
    }
}
