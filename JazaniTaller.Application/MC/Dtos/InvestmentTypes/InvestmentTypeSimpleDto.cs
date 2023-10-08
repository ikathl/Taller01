using JazaniTaller.Domain.Cores.Models;

namespace JazaniTaller.Application.MC.Dtos.InvestmentTypes
{
    public class InvestmentTypeSimpleDto: CoreModel<int>
    {
        public string Name { get; set; }
    }
}
