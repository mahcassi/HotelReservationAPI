using Entity.Entity;
using Entity.Enums;
using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class RoomDTO
    {
        public ERoomType RoomType { get; set; }
        public decimal Price { get; set; }
        public string Number { get; set; }
        public bool Availability { get; set; }
        public string Size { get; set; }
        public IEnumerable<RoomAmenities> Amenities { get; set; }
        public Reservation Reservation { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
