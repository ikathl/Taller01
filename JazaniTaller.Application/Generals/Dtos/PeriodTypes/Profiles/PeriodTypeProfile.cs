using AutoMapper;
using JazaniTaller.Application.Generals.Dtos.MesureUnits;
using JazaniTaller.Domain.Generals.Models;

namespace JazaniTaller.Application.Generals.Dtos.PeriodTypes.Profiles
{
    public class PeriodTypeProfile : Profile
    {
        public PeriodTypeProfile()
        {
            CreateMap<PeriodType, PeriodTypeDto>();
            CreateMap<PeriodType, PeriodTypeSimpleDto>();

            CreateMap<PeriodType, PeriodTypeSaveDto>().ReverseMap();

        }
    }
}

