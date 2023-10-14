using JazaniTaller.Application.Admins.Dtos.Users;
using JazaniTaller.Application.Cores.Services;

namespace JazaniTaller.Application.Admins.Services
{
    public interface IUserService : ISaveService<UserDto, UserSaveDto, int>
    {
        Task<UserSecurityDto> LoginAsync(UserAuthDto userAuth);
    }
}
