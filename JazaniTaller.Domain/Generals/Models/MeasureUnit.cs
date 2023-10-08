using JazaniTaller.Domain.Cores.Models;
using JazaniTaller.Domain.MC.Models;

namespace JazaniTaller.Domain.Generals.Models
{
    public class MeasureUnit : CoreModel<int>
    {
        public int? MeasureUnitId { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string? Description { get; set; }
        public string? FormulaConversion { get; set; }

        public virtual ICollection<Investment> Investments { get; set; }
    }
}
