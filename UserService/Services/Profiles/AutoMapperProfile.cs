using AutoMapper;
using UserService.Domain.Dtos;
using UserService.Domain.Models;

namespace UserService.Services.Profiles
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<UserModel, UserDto>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.age, opt => opt.MapFrom(src => src.Age))
                .ForMember(dest => dest.birthday, opt => opt.MapFrom(src => src.Birthday))
                .ForMember(dest => dest.nationality, opt => opt.MapFrom(src => src.Nationality));

            CreateMap<CreateUserDto, UserModel>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Surname, opt => opt.MapFrom(src => src.Surname))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age))
                .ForMember(dest => dest.Roles , opt => opt.MapFrom(src => src.Roles))
                .ForMember(dest => dest.Nationality, opt => opt.MapFrom(src => src.Nationality))
                .ReverseMap();
        }
    }
}
