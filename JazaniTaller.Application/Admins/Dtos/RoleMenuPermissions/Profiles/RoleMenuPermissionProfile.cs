using JazaniTaller.Domain.Admins.Models;
using AutoMapper;


namespace JazaniTaller.Application.Admins.Dtos.RoleMenuPermissions.Profiles
{
    public class RoleMenuPermissionProfile:Profile
    {
        public RoleMenuPermissionProfile()
        {
            CreateMap<RoleMenuPermission, RoleMenuPermissionDto>();
            CreateMap<RoleMenuPermission, RoleMenuPermissionSaveDto>().ReverseMap();
        }
    }
    
}
