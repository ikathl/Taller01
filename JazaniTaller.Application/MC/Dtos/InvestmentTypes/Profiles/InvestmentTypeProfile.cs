using AutoMapper;
using JazaniTaller.Domain.MC.Models;

namespace JazaniTaller.Application.MC.Dtos.InvestmentTypes.Profiles
{
    public class InvestmentTypeProfile : Profile
    {
        public InvestmentTypeProfile()
        {
            CreateMap<InvestmentType, InvestmentTypeDto>();
            CreateMap<InvestmentType, InvestmentTypeSimpleDto>();

            CreateMap<InvestmentType, InvestmentTypeSaveDto>().ReverseMap();

        }
    }
}
