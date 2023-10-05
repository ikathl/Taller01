using JazaniTaller.Application.Admins.Dtos.Menus;

namespace JazaniTaller.Application.Admins.Services
{
    public interface IMenuService
    {
        Task<IReadOnlyList<MenuDto>> FindAllAsync();
        Task<MenuDto?> FindByIdAsync(int id);
        Task<MenuDto> CreateAsync(MenuSaveDto saveDto);
        Task<MenuDto> EditAsync(int id, MenuSaveDto saveDto);
        Task<MenuDto> DisableAsync(int id);
    }
}
