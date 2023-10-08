using JazaniTaller.Application.MC.Dtos.InvestmentsConcepts;

namespace JazaniTaller.Application.MC.Services
{
    public interface IInvestmentConceptService
    {
        Task<IReadOnlyList<InvestmentConceptDto>> FindAllAsync();
        Task<InvestmentConceptDto?> FindByIdAsync(int id);
        Task<InvestmentConceptDto> CreateAsync(InvestmentConceptSaveDto saveDto);
        Task<InvestmentConceptDto> EditAsync(int id, InvestmentConceptSaveDto saveDto);
        Task<InvestmentConceptDto> DisableAsync(int id);
    }
}
