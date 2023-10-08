using AutoMapper;
using JazaniTaller.Domain.SOC.Models;

namespace JazaniTaller.Application.SOC.Dtos.Holders.Profiles
{
    public class HolderProfile : Profile
    {
        public HolderProfile()
        {
            CreateMap<Holder, HolderDto>();
            CreateMap<Holder, HolderSimpleDto>();
            CreateMap<Holder, HolderSaveDto>().ReverseMap();

        }
    }
}
