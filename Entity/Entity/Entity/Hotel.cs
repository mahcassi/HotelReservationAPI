namespace Entity.Entity
{
    public class Hotel : BaseEntity
    {
        public string Name { get; set; }
        public AddressHotel AddressHotel { get; set; }
        public IEnumerable<HotelAmenities> Amenities { get; set; }

        public IEnumerable<Room> Rooms { get; set; }
    }
}
