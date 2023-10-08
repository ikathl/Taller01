using JazaniTaller.Domain.Generals.Models;
using JazaniTaller.Domain.Generals.Repositories;
using JazaniTaller.Infraestructure.Cores.Contexts;
using JazaniTaller.Infraestructure.Cores.Persistances;

namespace JazaniTaller.Infraestructure.Generals.Persistances
{
    internal class MeasureUnitRepository : CrudRepository<MeasureUnit, int>, IMeasureUnitRepository
    {
        //private readonly ApplicationDbContext _dbContext;
        public MeasureUnitRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            //_dbContext = dbContext;
        }

        //public override async Task<IReadOnlyList<Investment>> FindAllAsync()
        //{
        //    return await _dbContext.Set<Menu>()
        //        .Include(t => t.MenuPadre)
        //        .AsNoTracking()
        //        .ToListAsync();
        //}
    }
}
