using AutoMapper;
using HotelService.Domain.Dtos;
using HotelService.Models.Models;

namespace HotelService.Services.MapperService
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Hotel, HotelCreationDto>()
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.stars, opt => opt.MapFrom(src => src.Stars))
                .ForMember(dest => dest.location, opt => opt.MapFrom(src => src.Location))
                .ReverseMap();

            CreateMap<Floor, FloorCreationDto>()
                .ForMember(dest => dest.hotelId, opt => opt.MapFrom(src => src.HotelId))
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
                .ReverseMap();
        
            CreateMap<Room, RoomCreationDto>()
                .ForMember(dest => dest.floorId, opt => opt.MapFrom(src => src.FloorId))
                .ForMember(dest => dest.roomType, opt => opt.MapFrom(src => src.RoomType))
                .ReverseMap();

            CreateMap<Facility, FacilityCreationDto>()
                .ForMember(dest => dest.floorId, opt => opt.MapFrom(src => src.FloorId))
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.description, opt => opt.MapFrom(src => src.Description))
                .ReverseMap();
                
        }
    }
}
