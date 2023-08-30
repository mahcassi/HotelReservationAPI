using API.DTO;
using AutoMapper;
using Entity.Entity;

namespace API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Hotel, HotelRequestDTO>().ReverseMap();
            CreateMap<Hotel, HotelDTO>().ReverseMap();
            CreateMap<AmenityHotel, AmenityHotelDTO>().ReverseMap();
            CreateMap<HotelAmenity, HotelAmenitiesDTO>().ReverseMap();
            CreateMap<AddressHotel, AddressHotelDTO>().ReverseMap();
        }
    }
}
