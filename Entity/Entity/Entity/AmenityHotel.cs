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

        public IEnumerable<HotelAmenity> HotelAmenities { get; set; }
    }
}
