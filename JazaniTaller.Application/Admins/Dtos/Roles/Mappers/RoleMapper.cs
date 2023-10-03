using AutoMapper;
using JazaniTaller.Domain.Admins.Models;

namespace JazaniTaller.Application.Admins.Dtos.Roles.Mappers
{
    public class RoleMapper:Profile
    {
        public RoleMapper()
        {
            CreateMap<Role, RoleDto>();
        }
    }
}
