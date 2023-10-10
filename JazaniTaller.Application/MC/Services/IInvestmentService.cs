using JazaniTaller.Application.Cores.Services;
using JazaniTaller.Application.MC.Dtos.Investments;

namespace JazaniTaller.Application.MC.Services
{
    public interface IInvestmentService: ICrudService<InvestmentDto, InvestmentSaveDto,int>,IPaginatedService<InvestmentDto, InvestmentFilterDto>
    {
    }
}
