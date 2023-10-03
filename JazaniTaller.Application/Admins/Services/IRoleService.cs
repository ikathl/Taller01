using JazaniTaller.Application.Admins.Dtos.Roles;

namespace JazaniTaller.Application.Admins.Services
{
    public interface IRoleService
    {
        Task<IReadOnlyList<RoleDto>> FindAllAsync();
        Task<RoleDto?> FindByIdAsync(int id);
        Task<RoleDto> CreateAsync(RoleSaveDto saveDto);
        Task<RoleDto> EditAsync(int id, RoleSaveDto saveDto);
        Task<RoleDto> DisableAsync(int id);
    }
}
