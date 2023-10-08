using AutoMapper;
using JazaniTaller.Domain.MC.Models;

namespace JazaniTaller.Application.MC.Dtos.InvestmentsConcepts.Profiles
{
    public class InvestmentConceptProfile : Profile
    {
        public InvestmentConceptProfile()
        {
            CreateMap<InvestmentConcept, InvestmentConceptDto>();

            CreateMap<InvestmentConcept, InvestmentConceptSaveDto>().ReverseMap();

        }
    }
}