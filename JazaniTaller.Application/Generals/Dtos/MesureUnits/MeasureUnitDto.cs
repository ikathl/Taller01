using JazaniTaller.Domain.Cores.Models;

namespace JazaniTaller.Application.Generals.Dtos.MesureUnits
{
    public class MeasureUnitDto : CoreModel<int>
    {
        public int? MeasureUnitId { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string? Description { get; set; }
        public string? FormulaConversion { get; set; }
    }
}
