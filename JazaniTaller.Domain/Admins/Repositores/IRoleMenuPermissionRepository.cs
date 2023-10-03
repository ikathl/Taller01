using JazaniTaller.Domain.Admins.Models;

namespace JazaniTaller.Domain.Admins.Repositores
{
    public interface IRoleMenuPermissionRepository
    {
        Task<IReadOnlyList<RoleMenuPermission>> FindAllAsync();
        Task<RoleMenuPermission?> FindByIdAsync(int id);
        Task<RoleMenuPermission?> SaveAsync(RoleMenuPermission office);
        Task<RoleMenuPermission?> FindByIdCompuesto(int roleId, int menuId, int permissionId);
    }
}
