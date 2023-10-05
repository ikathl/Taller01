using AutoMapper;
using JazaniTaller.Domain.Admins.Models;

namespace JazaniTaller.Application.Admins.Dtos.Menus.Profiles
{
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            CreateMap<Menu, MenuDto>();
            CreateMap<Menu, MenuSimpleDto>();
            CreateMap<Menu, MenuSaveDto>().ReverseMap();
        }
    }
}
