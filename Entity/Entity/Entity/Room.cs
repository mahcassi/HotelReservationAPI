using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Entity.Entity
{
    public class Room
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string RoomType { get; set; } 
        public double Price { get; set; }
        public bool Availability { get; set; }
        public string Size { get; set; }
        public IEnumerable<RoomAmenities> Amenities { get; set; } 
        public IEnumerable<Reservation> Reservations { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
