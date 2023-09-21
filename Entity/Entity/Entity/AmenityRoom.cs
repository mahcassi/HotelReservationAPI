namespace Entity.Entity
{
    public class AmenityRoom : BaseEntity
    {
        public string Name { get; set; }

        public IEnumerable<RoomAmenity> RoomAmenities { get; set; }
    }
}
