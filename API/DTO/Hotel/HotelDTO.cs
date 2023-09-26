using System.ComponentModel.DataAnnotations;
using API.DTO.Room;

namespace API.DTO.Hotel
{
    public class HotelDTO
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Description { get; set; }

        public string CNPJ { get; set; }

        public AddressHotelDTO AddressHotel { get; set; }

        public IEnumerable<HotelAmenitiesDTO> HotelAmenities { get; set; }

        public IEnumerable<RoomDTO> Rooms { get; set; }
    }
}
