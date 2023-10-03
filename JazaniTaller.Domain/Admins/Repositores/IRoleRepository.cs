using JazaniTaller.Domain.Admins.Models;

namespace JazaniTaller.Domain.Admins.Repositores
{
    public interface IRoleRepository
    {
        Task<IReadOnlyList<Role>> FindAllAsync();
        Task<Role?> FindByIdAsync(int id);
        Task<Role?> SaveAsync(Role office);
    }
}
