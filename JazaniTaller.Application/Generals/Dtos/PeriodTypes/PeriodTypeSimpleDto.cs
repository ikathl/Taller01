using JazaniTaller.Domain.Cores.Models;

namespace JazaniTaller.Application.Generals.Dtos.PeriodTypes
{
    public class PeriodTypeSimpleDto : CoreModel<int>
    {
        public string Name { get; set; }
    }
}
