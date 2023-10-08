using JazaniTaller.Domain.MC.Models;
using JazaniTaller.Domain.MC.Repositories;
using JazaniTaller.Infraestructure.Cores.Contexts;
using JazaniTaller.Infraestructure.Cores.Persistances;
using Microsoft.EntityFrameworkCore;

namespace JazaniTaller.Infraestructure.MC.Persistances
{
    public class InvestmentRepository : CrudRepository<Investment, int>, IInvestmentRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public InvestmentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public override async Task<IReadOnlyList<Investment>> FindAllAsync()
        {
            return await _dbContext.Set<Investment>()
                .Include(t => t.Holder)
                .Include(t => t.InvestmentType)
                .Include(t => t.MiningConcession)
                .Include(t => t.PeriodType)
                .Include(t => t.MeasureUnit)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}