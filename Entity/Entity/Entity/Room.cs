using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Entity.Enums;

namespace Entity.Entity
{
    public class Room : BaseEntity
    {
        public ERoomType RoomType { get; set; } 
        public double Price { get; set; }
        public bool Availability { get; set; }
        public string Size { get; set; }
        public IEnumerable<RoomAmenities> Amenities { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
