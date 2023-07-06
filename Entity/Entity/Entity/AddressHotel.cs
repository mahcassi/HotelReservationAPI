using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class AddressHotel : AddressEntity
    {
        public Guid HotelId { get; set; }
        public Hotel Hotel { get; set; }
    }
}
