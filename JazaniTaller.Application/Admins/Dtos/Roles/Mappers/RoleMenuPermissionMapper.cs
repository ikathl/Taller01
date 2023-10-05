using JazaniTaller.Domain.Admins.Models;
using AutoMapper;
using JazaniTaller.Application.Admins.Dtos.RoleMenuPermissions;

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
