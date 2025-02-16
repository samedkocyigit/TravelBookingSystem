using AutoMapper;
using HotelService.Domain.Dtos;
using HotelService.Domain.Enums;
using HotelService.Models.Enums;
using HotelService.Models.Models;

namespace HotelService.Services.Profiles
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Hotel, HotelCreationDto>()
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.stars, opt => opt.MapFrom(src => src.Stars))
                .ForMember(dest => dest.location, opt => opt.MapFrom(src => src.Location))
                .ReverseMap();
            
            CreateMap<Floor, FloorCreationDto>()
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.hotelId, opt => opt.MapFrom(src => src.HotelId))
                .ReverseMap();
            
            CreateMap<Room, RoomCreationDto>()
                .ForMember(dest => dest.floorId, opt => opt.MapFrom(src => src.FloorId))
                .ForMember(dest => dest.roomType, opt => opt.MapFrom(src => src.RoomType))
                .ReverseMap();
            CreateMap<Facility, FacilityCreationDto>()
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.floorId, opt => opt.MapFrom(src => src.FloorId))
                .ReverseMap();
            CreateMap<RoomType, string>().ConvertUsing(src => src.ToString());
            CreateMap<IsBooked, string>().ConvertUsing(src => src.ToString());

            CreateMap<Room, AvailableRoomDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.RoomType, opt => opt.MapFrom(src => src.RoomType.ToString())) 
                .ForMember(dest => dest.RoomCapacity, opt => opt.MapFrom(src => src.RoomCapacity))
                .ForMember(dest => dest.PricePerNight, opt => opt.MapFrom(src => src.PricePerNight))
                .ForMember(dest => dest.RoomNumber, opt => opt.MapFrom(src => src.RoomNumber))
                .ForMember(dest => dest.IsBooked, opt => opt.MapFrom(src => src.IsBooked.ToString())) 
                .ReverseMap();


            CreateMap<Hotel,AvailableRoomsDto>()
                .ForMember(dest => dest.HotelId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.HotelName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.HotelLocation, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.HotelStars, opt => opt.MapFrom(src => src.Stars))
                .ForMember(dest => dest.Rooms, opt => opt.MapFrom(src => src.Floors.SelectMany(f => f.Rooms)))
                .ReverseMap();
        }

    }
}
