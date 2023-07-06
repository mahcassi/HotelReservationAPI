using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Room
    {
        public Guid Id { get; set; }
        public string RoomType { get; set; } 
        public double Price { get; set; }
        public bool Availability { get; set; }
        public double Size { get; set; }
        public string Amenities { get; set; } 
        public IEnumerable<Reservation> Reservations { get; set; }
        public Guid HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
