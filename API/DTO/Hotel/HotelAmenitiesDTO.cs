using Entity.Entity;
using System.ComponentModel.DataAnnotations;

namespace API.DTO.Hotel
{
    public class HotelAmenitiesDTO
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int AmenityId { get; set; }
        public HotelRequestDTO Hotel { get; set; }
        public AmenityHotelDTO AmenityHotel { get; set; }
    }
}
