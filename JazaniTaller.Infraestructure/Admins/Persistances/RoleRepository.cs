using JazaniTaller.Domain.Admins.Models;
using JazaniTaller.Domain.Admins.Repositores;
using JazaniTaller.Infraestructure.Cores.Contexts;
using JazaniTaller.Infraestructure.Cores.Persistances;

namespace JazaniTaller.Infraestructure.Admins.Persistances
{
    public class RoleRepository : CrudRepository<Role, int>, IRoleRepository
    {
        public RoleRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
