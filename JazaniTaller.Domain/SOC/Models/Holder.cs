using JazaniTaller.Domain.Cores.Models;
using JazaniTaller.Domain.MC.Models;

namespace JazaniTaller.Domain.SOC.Models
{
    public class Holder:CoreModel<int>
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string MaidenName { get; set; }
        public string DocumentNumber { get; set; }
        public string? LandLine { get; set; }
        public string? Mobile { get; set; }
        public string? Corporatemail { get; set; }
        public string? PersonalMail { get; set; }

        public virtual ICollection<Investment> Investments { get; set; }
    }
}
