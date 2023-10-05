using JazaniTaller.Domain.Admins.Models;
using JazaniTaller.Domain.Cores.Repositories;

namespace JazaniTaller.Domain.Admins.Repositores
{
    public interface IRoleMenuPermissionRepository:ICrudRepository<RoleMenuPermission, int>
    {
        Task<RoleMenuPermission?> FindByIdCompuesto(int roleId, int menuId, int permissionId);
    }
}
