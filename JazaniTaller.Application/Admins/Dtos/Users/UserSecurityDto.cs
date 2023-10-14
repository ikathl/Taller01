using JazaniTaller.Core.Securities.Entities;

namespace JazaniTaller.Application.Admins.Dtos.Users
{
    public class UserSecurityDto : UserDto
    {
        public SecurityEntity Security { get; set; }
    }
}
