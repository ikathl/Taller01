using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazaniTaller.Application.Admins.Dtos.RoleMenuPermissions
{
    public class RoleMenuPermissionSaveDto
    {
        public int RoleId { get; set; }
        public int MenuId { get; set; }
        public int PermissionId { get; set; }
    }
}
