using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Entity.Enums;

namespace Entity.Entity
{
    public class Room : BaseEntity
    {
        public ERoomType RoomType { get; set; } 
        public decimal Price { get; set; }
        public string Number { get; set; }
        public bool Availability { get; set; }
        public string Size { get; set; }
        public Reservation Reservation { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
        public IEnumerable<RoomAmenity> RoomAmenities { get; set; }
    }
}
