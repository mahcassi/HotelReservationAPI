namespace Entity.Entity
{
    public class RoomAmenities : BaseEntity
    {
        public string Name { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}
