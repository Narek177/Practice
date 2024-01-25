using AutoMapper;
using DataAccessLayer.Entities;
using Practice.Models;

namespace Practice.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<UserDetails, UserDetailsViewModel>();
            CreateMap<User, UserViewModel>();
            CreateMap<User, CreateUserViewModel>();
            CreateMap<CreateUserViewModel, User>();
            CreateMap<User, EditUserViewModel>();
        }
    }
}
