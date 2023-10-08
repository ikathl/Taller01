using AutoMapper;
using JazaniTaller.Domain.MC.Models;

namespace JazaniTaller.Application.MC.Dtos.Investments.Profiles
{
    public class InvestmentProfile : Profile
    {
        public InvestmentProfile()
        {
            CreateMap<Investment, InvestmentDto>();

            CreateMap<Investment, InvestmentSaveDto>().ReverseMap();

        }
    }
}
