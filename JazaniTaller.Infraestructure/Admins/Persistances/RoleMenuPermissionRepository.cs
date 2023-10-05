using JazaniTaller.Domain.Admins.Models;
using JazaniTaller.Domain.Admins.Repositores;
using JazaniTaller.Infraestructure.Cores.Contexts;
using JazaniTaller.Infraestructure.Cores.Persistances;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazaniTaller.Infraestructure.Admins.Persistances
{
    public class RoleMenuPermissionRepository:CrudRepository<RoleMenuPermission, int>, IRoleMenuPermissionRepository
    {
        public RoleMenuPermissionRepository(ApplicationDbContext context) : base(context)
        {

        }

        //public async Task<RoleMenuPermission?> FindByIdCompuesto(int roleId, int menuId, int permissionId)
        //{
        //    return await FirstOrDefaultAsync(x => x.RoleId == roleId && x.MenuId == menuId && x.PermissionId == permissionId);
        //}
    }
}
