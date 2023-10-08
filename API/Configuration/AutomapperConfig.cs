using API.DTO;
using API.DTO.Hotel;
using API.DTO.Room;
using AutoMapper;
using Entity.Entity;

namespace API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            //Hotel
            CreateMap<Hotel, HotelRequestDTO>().ReverseMap();
            CreateMap<Hotel, HotelDTO>().ReverseMap();
            CreateMap<AmenityHotel, AmenityHotelDTO>().ReverseMap();
            CreateMap<HotelAmenity, HotelAmenitiesDTO>().ReverseMap();
            CreateMap<AddressHotel, AddressHotelDTO>().ReverseMap();

            //Room
            CreateMap<Room, RoomDTO>().ReverseMap();
            CreateMap<Room, RoomRequestDTO>().ReverseMap();
        }
    }
}
