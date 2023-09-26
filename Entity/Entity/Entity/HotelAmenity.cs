namespace Entity.Entity
{
    public class HotelAmenity
    {
        public int HotelId { get; set; }
        public int AmenityId { get; set; }
        public Hotel Hotel { get; set; }
        public AmenityHotel AmenityHotel { get; set; }
    }
}
