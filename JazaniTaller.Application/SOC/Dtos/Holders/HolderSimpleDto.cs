using JazaniTaller.Domain.Cores.Models;

namespace JazaniTaller.Application.SOC.Dtos.Holders
{
    public class HolderSimpleDto : CoreModel<int>
    {
        public string Name { get; set; }
    }
}
