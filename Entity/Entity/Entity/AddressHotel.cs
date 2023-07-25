namespace Entity.Entity
{
    public class AddressHotel : AddressEntity
    {
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
