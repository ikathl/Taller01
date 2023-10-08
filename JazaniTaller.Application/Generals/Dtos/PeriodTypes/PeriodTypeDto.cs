using JazaniTaller.Domain.Cores.Models;

namespace JazaniTaller.Application.Generals.Dtos.PeriodTypes
{
    public class PeriodTypeDto : CoreModel<int>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? Time { get; set; }
    }
}
