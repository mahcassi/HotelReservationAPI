namespace Entity.Entity
{
    public class HotelAmenities : BaseEntity
    {
        public string Name { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

    }
}
