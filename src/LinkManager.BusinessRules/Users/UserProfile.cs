using AutoMapper;
using LinkManager.BusinessRules.Users.Requests;
using LinkManager.BusinessRules.Users.Responses;
using LinkManager.Domain.Entities;

namespace LinkManager.BusinessRules.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserRequest, User>();
            CreateMap<UpdateUserRequest, User>();
            CreateMap<UpdatePasswordRequest, User>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.NewPassword));
            CreateMap<User, UserResponseItem>();
        }
    }
}