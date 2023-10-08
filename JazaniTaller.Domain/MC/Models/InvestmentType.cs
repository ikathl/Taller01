using JazaniTaller.Domain.Cores.Models;

namespace JazaniTaller.Domain.MC.Models
{
    public class InvestmentType: CoreModel<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Investment> Investments { get; set; }
    }
}
