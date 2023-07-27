using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Hotel : BaseEntity
    {
        public string Name { get; set; }
        public AddressHotel AddressHotel { get; set; }
        public IEnumerable<HotelAmenities> Amenities { get; set; }

        public IEnumerable<Room> Rooms { get; set; }
    }
}
