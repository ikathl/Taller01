using JazaniTaller.Core.Paginations;
using JazaniTaller.Domain.Cores.Paginations;
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
        private readonly IPaginator<Investment> _paginator;
        public InvestmentRepository(ApplicationDbContext dbContext, IPaginator<Investment> paginator) : base(dbContext)
        {
            _dbContext = dbContext;
            _paginator = paginator;
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
        public async Task<ResponsePagination<Investment>> PaginatedSearch(RequestPagination<Investment> request)
        {
            var filter = request.Filter;

            var query = _dbContext.Set<Investment>().Include(t => t.Holder)
                .Include(t => t.InvestmentType)
                .Include(t => t.MiningConcession)
                .Include(t => t.PeriodType)
                .Include(t => t.MeasureUnit)
                .AsNoTracking().AsQueryable();

            if (filter is not null)
            {
                query = query
                    .Where(x =>
                        (string.IsNullOrWhiteSpace(filter.Description) || x.Description.ToUpper().Contains(filter.Description.ToUpper()))
                        && (string.IsNullOrWhiteSpace(filter.AccreditationCode) || x.AccreditationCode.ToUpper().Contains(filter.AccreditationCode.ToUpper()))
                        && (string.IsNullOrWhiteSpace(filter.MonthName) || x.MonthName.ToUpper().Contains(filter.MonthName.ToUpper()))
                    );
            }


            query = query.OrderBy(x => x.Id);


            return await _paginator.Paginate(query, request);
        }
    }
}