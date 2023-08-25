namespace Entity.Entity
{
    public class Hotel : BaseEntity
    {
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public AddressHotel AddressHotel { get; set; }
        public IEnumerable<HotelAmenity> HotelAmenities { get; set; }
    }
}
