using AutoMapper;
using JazaniTaller.Domain.Admins.Models;

namespace JazaniTaller.Application.Admins.Dtos.Users.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<User, UserSecurityDto>();

            CreateMap<User, UserSaveDto>().ReverseMap();
        }
    }
}
