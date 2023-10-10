using AutoMapper;
using JazaniTaller.Core.Paginations;
using JazaniTaller.Domain.MC.Models;

namespace JazaniTaller.Application.MC.Dtos.Investments.Profiles
{
    public class InvestmentProfile : Profile
    {
        public InvestmentProfile()
        {
            CreateMap<Investment, InvestmentDto>();

            CreateMap<Investment, InvestmentSaveDto>().ReverseMap();

            CreateMap<Investment, InvestmentFilterDto>().ReverseMap();

            CreateMap<ResponsePagination<Investment>, ResponsePagination<InvestmentDto>>();
            CreateMap<RequestPagination<Investment>, RequestPagination<InvestmentFilterDto>>().ReverseMap();

        }
    }
}
