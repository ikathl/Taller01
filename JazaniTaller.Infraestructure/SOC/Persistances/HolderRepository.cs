using JazaniTaller.Domain.SOC.Models;
using JazaniTaller.Domain.SOC.Repositories;
using JazaniTaller.Infraestructure.Cores.Contexts;
using JazaniTaller.Infraestructure.Cores.Persistances;

namespace JazaniTaller.Infraestructure.SOC.Persistances
{
    public class HolderRepository : CrudRepository<Holder, int>, IHolderRepository
    {
        //private readonly ApplicationDbContext _dbContext;
        public HolderRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            //_dbContext = dbContext;
        }

        //public override async Task<IReadOnlyList<Holder>> FindAllAsync()
        //{
        //    return await _dbContext.Set<Menu>()
        //        .Include(t => t.MenuPadre)
        //        .AsNoTracking()
        //        .ToListAsync();
        //}
    }
}