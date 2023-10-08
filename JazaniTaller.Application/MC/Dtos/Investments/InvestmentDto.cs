using JazaniTaller.Application.Generals.Dtos.MesureUnits;
using JazaniTaller.Application.Generals.Dtos.PeriodTypes;
using JazaniTaller.Application.MC.Dtos.InvestmentTypes;
using JazaniTaller.Application.MC.Dtos.MiningConcessions;
using JazaniTaller.Application.SOC.Dtos.Holders;
namespace JazaniTaller.Application.MC.Dtos.Investments
{
    public class InvestmentDto
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
    
        public HolderSimpleDto? Holder { get; set; }
        public InvestmentTypeSimpleDto? InvestmentType { get; set; }
        public MeasureUnitSimpleDto? MeasureUnit { get; set; }
        public MiningConcessionSimpleDto? MiningConcession { get; set; }
        public PeriodTypeSimpleDto? PeriodType { get; set; }
    }
}
