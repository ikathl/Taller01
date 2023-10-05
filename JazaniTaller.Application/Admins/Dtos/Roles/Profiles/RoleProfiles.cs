using AutoMapper;
using JazaniTaller.Domain.Admins.Models;

namespace JazaniTaller.Application.Admins.Dtos.Roles.Profiles
{
    public class RoleProfiles : Profile
    {
        public RoleProfiles() {
            CreateMap<Role, RoleDto>();
            CreateMap<Role, RoleSaveDto>().ReverseMap();
        }
    }
}
