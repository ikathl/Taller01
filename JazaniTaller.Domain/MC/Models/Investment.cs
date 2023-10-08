using JazaniTaller.Domain.Generals.Models;
using JazaniTaller.Domain.SOC.Models;

namespace JazaniTaller.Domain.MC.Models
{
    public class Investment
    {
        public int Id { get; set; }
        public decimal AmountInvested { get; set; }
        public int? Year { get; set; }
        public string? Description { get; set; }
        public int MiningConcessionId { get; set; }
        public int InvestmentTypeId { get; set; }
        public int CurrencyTypeId { get; set; }
        public int? PeriodTypeId { get; set; }
        public int? MeasureUnitId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public bool State { get; set; }
        public string? MonthName { get; set; }
        public int? MonthId { get; set; }
        public string? AccreditationCode { get; set; }
        public string? AccountantCode { get; set; }
        public int HolderId { get; set; }
        public int DeclaredTypeId { get; set; }
        public int? DocumentId { get; set; }
        public int? InvestmentConceptId { get; set; }
        public bool? Module { get; set; }
        public int? Frecuency { get; set; }
        public int? IsDAC { get; set; }
        public string? MetricTons { get; set; }
        public DateTime? DeclarationDate { get; set; }
    
        public virtual Holder? Holder { get; set; }
        public virtual InvestmentType? InvestmentType { get; set; }
        public virtual MeasureUnit? MeasureUnit { get; set; }
        public virtual MiningConcession? MiningConcession { get; set; }
        public virtual PeriodType? PeriodType { get; set; }
    }
}
