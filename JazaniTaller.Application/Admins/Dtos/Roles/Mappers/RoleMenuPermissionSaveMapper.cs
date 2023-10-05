using AutoMapper;
using JazaniTaller.Application.Admins.Dtos.RoleMenuPermissions;
using JazaniTaller.Domain.Admins.Models;

namespace JazaniTaller.Application.Admins.Dtos.Roles.Mappers
{
    public class RoleMenuPermissionSaveMapper : Profile
    {
        public RoleMenuPermissionSaveMapper()
        {
            CreateMap<RoleMenuPermission, RoleMenuPermissionSaveDto>().ReverseMap();
        }
    }
}
