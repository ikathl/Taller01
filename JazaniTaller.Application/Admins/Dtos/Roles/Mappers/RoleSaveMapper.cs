using AutoMapper;
using JazaniTaller.Domain.Admins.Models;

namespace JazaniTaller.Application.Admins.Dtos.Roles.Mappers
{
    public class RoleSaveMapper:Profile
    {
        public RoleSaveMapper()
        {
            CreateMap<Role, RoleSaveDto>().ReverseMap();
        }
    }
}
