﻿namespace Entity.Entity
{
    public class RoomAmenity 
    {
        public int RoomId { get; set; }
        public int AmenityId { get; set; }
        public Room Room { get; set; }
        public AmenityRoom AmenityRoom { get; set; }
    }
}