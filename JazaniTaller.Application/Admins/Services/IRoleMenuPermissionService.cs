using JazaniTaller.Application.Admins.Dtos.Roles;
using JazaniTaller.Domain.Admins.Models;

namespace JazaniTaller.Application.Admins.Services
{
    public interface IRoleMenuPermissionService
    {
        Task<IReadOnlyList<RoleMenuPermissionDto>> FindAllAsync();
        Task<RoleMenuPermissionDto?> FindByIdAsync(int id);
        Task<RoleMenuPermissionDto?> FindByIdCompuesto(int roleId, int menuId, int permissionId);
        Task<RoleMenuPermissionDto> CreateAsync(RoleMenuPermissionSaveDto saveDto);
        Task<RoleMenuPermissionDto> EditAsync(int id, RoleMenuPermissionSaveDto saveDto);
        Task<RoleMenuPermissionDto> DisableAsync(int id);
    }
}
