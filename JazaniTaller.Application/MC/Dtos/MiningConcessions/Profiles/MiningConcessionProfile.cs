using AutoMapper;
using JazaniTaller.Domain.MC.Models;

namespace JazaniTaller.Application.MC.Dtos.MiningConcessions.Profiles
{
    public class MiningConcessionProfile : Profile
    {
        public MiningConcessionProfile()
        {
            CreateMap<MiningConcession, MiningConcessionDto>();
            CreateMap<MiningConcession, MiningConcessionSimpleDto>();

            CreateMap<MiningConcession, MiningConcessionSaveDto>().ReverseMap();

        }
    }
}