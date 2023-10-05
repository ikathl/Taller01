using JazaniTaller.Domain.Admins.Models;
using JazaniTaller.Domain.Admins.Repositores;
using JazaniTaller.Infraestructure.Cores.Contexts;
using JazaniTaller.Infraestructure.Cores.Persistances;
using Microsoft.EntityFrameworkCore;

namespace JazaniTaller.Infraestructure.Admins.Persistances
{
    public class MenuRepository : CrudRepository<Menu, int>, IMenuRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public MenuRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<IReadOnlyList<Menu>> FindAllAsync()
        {
            return await _dbContext.Set<Menu>()
                .Include(t => t.MenuPadre)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
