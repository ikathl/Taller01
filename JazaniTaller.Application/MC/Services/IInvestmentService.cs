using JazaniTaller.Application.MC.Dtos.Investments;

namespace JazaniTaller.Application.MC.Services
{
    public interface IInvestmentService
    {
        Task<IReadOnlyList<InvestmentDto>> FindAllAsync();
        Task<InvestmentDto?> FindByIdAsync(int id);
        Task<InvestmentDto> CreateAsync(InvestmentSaveDto saveDto);
        Task<InvestmentDto> EditAsync(int id, InvestmentSaveDto saveDto);
        Task<InvestmentDto> DisableAsync(int id);
    }
}
