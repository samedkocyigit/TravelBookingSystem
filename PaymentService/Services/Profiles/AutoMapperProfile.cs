using AutoMapper;
using PaymentService.Domain.Dtos;
using PaymentService.Domain.Models;

namespace PaymentService.Services.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PaymentCreationDto, Payment>()
                .ForMember(dest => dest.CardNumber, opt => opt.MapFrom(src => src.CardNumber))
                .ForMember(dest => dest.CardHolderName, opt => opt.MapFrom(src => src.CardHolderName))
                .ForMember(dest => dest.ExpiryDate, opt => opt.MapFrom(src => src.ExpiryDate))
                .ForMember(dest => dest.CVV, opt => opt.MapFrom(src => src.CVV))
                .ForMember(dest => dest.UserToBeCharged, opt => opt.MapFrom(src => src.UserToBeCharged))
                .ForMember(dest => dest.BookingId, opt => opt.MapFrom(src => src.BookingId))
                .ReverseMap();
        }
    }
}
