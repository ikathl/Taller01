﻿using JazaniTaller.Domain.MC.Models;
using JazaniTaller.Domain.MC.Repositories;
using JazaniTaller.Infraestructure.Cores.Contexts;
using JazaniTaller.Infraestructure.Cores.Persistances;

namespace JazaniTaller.Infraestructure.MC.Persistances
{
    public class InvestmentConceptRepository : CrudRepository<InvestmentConcept, int>, IInvestmentConceptRepository
    {
        //private readonly ApplicationDbContext _dbContext;
        public InvestmentConceptRepository(ApplicationDbContext dbContext) : base(dbContext)
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