using API.DTO;
using AutoMapper;
using Entity.Entity;

namespace API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Hotel, HotelDTO>().ReverseMap();
            
        }
    }
}
