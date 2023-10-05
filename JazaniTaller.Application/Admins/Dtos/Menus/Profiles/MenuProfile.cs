using AutoMapper;
using JazaniTaller.Domain.Admins.Models;

namespace JazaniTaller.Application.Admins.Dtos.Menus.Profiles
{
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            CreateMap<Domain.Admins.Models.Menu, MenuDto>();
            CreateMap<Domain.Admins.Models.Menu, MenuSaveDto>().ReverseMap();
        }
    }
}
