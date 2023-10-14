using JazaniTaller.Domain.Admins.Models;
using JazaniTaller.Domain.Cores.Repositories;

namespace JazaniTaller.Domain.Admins.Repositores
{
    public interface IUserRepository : ICrudRepository<User, int>
    {
        Task<User?> FindByEmailAsync(string email);
    }
}
