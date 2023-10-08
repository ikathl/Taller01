using AutoMapper;
using JazaniTaller.Application.Admins.Dtos.Menus.Profiles.Mappers;
using JazaniTaller.Domain.Admins.Models;

namespace JazaniTaller.Application.Admins.Dtos.Menus.Profiles
{
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            CreateMap<Menu, MenuDto>()
                .AfterMap<MenuMapper>();
            CreateMap<Menu, MenuSimpleDto>();
            CreateMap<Menu, MenuSaveDto>().ReverseMap();
        }
    }
}
