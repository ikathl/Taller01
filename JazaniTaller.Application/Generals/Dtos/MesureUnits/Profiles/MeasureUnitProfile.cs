using AutoMapper;
using JazaniTaller.Domain.Generals.Models;

namespace JazaniTaller.Application.Generals.Dtos.MesureUnits.Profiles
{
    public class MeasureUnitProfile : Profile
    {
        public MeasureUnitProfile()
        {
            CreateMap<MeasureUnit, MeasureUnitDto>();
            CreateMap<MeasureUnit, MeasureUnitSimpleDto>();

            CreateMap<MeasureUnit, MeasureUnitSaveDto>().ReverseMap();

        }
    }
}
