using JazaniTaller.Domain.Cores.Models;
using JazaniTaller.Domain.MC.Models;

namespace JazaniTaller.Domain.Generals.Models
{
    public class PeriodType : CoreModel<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? Time { get; set; }
        public virtual ICollection<Investment> Investments { get; set; }
    }
}
