using JazaniTaller.Domain.Admins.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JazaniTaller.Domain.Admins.Repositores
{
    public interface IRoleMenuPermission
    {
        Task<IReadOnlyList<RoleMenuPermission>> FindAllAsync();
        Task<RoleMenuPermission?> FindByIdAsync(int id);
        Task<RoleMenuPermission?> SaveAsync(RoleMenuPermission office);
    }
}
