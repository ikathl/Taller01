using JazaniTaller.Application.Admins.Dtos.Menus;
using JazaniTaller.Application.Admins.Dtos.Roles;

namespace JazaniTaller.Application.Admins.Dtos.RoleMenuPermissions
{
    public class RoleMenuPermissionDto
    {
        public int RoleId { get; set; }
        public int MenuId { get; set; }
        public int PermissionId { get; set; }
        public DateTimeOffset RegistrationDate { get; set; }
        public bool State { get; set; }
        public MenuSimpleDto Menu { get; set; }
        public RoleSimpleDto Role { get; set; }
    }
}
