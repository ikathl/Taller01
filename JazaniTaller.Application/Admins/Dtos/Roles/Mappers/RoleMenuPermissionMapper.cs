using JazaniTaller.Domain.Admins.Models;
using AutoMapper;

namespace JazaniTaller.Application.Admins.Dtos.Roles.Mappers
{
    public class RoleMenuPermissionMapper : Profile
    {
        public RoleMenuPermissionMapper()
        {
            CreateMap<RoleMenuPermission, RoleMenuPermissionDto>();
        }
    }
}
