using Entity.Entity;

namespace API.DTO.Room
{
    public class RoomRequestDTO
    {
        public int Id { get; set; }

        public string RoomType { get; set; }

        public decimal Price { get; set; }
        public string Number { get; set; }

        public bool Availability { get; set; }

        public string Size { get; set; }

        public Reservation? Reservation { get; set; }

        public int HotelId { get; set; }

        public IEnumerable<int> AmenitiesIds { get; set; }
    }
}
