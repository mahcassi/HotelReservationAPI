using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class AmenityHotel : BaseEntity
    {
        public string Name { get; set; }

        // relacionamento N:N - Amenity tem varias hotelAmenities
        public IEnumerable<HotelAmenity> HotelAmenities { get; set; }
    }
}
