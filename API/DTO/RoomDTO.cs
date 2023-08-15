using Entity.Entity;
using Entity.Enums;
using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class RoomDTO
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public ERoomType RoomType { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Number { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public bool Availability { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Size { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public IEnumerable<RoomAmenities> Amenities { get; set; }

        public Reservation Reservation { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
