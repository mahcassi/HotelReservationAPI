using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Hotel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }  
        public int NumberRooms { get; set; }
        public string Amenities { get; set; }  // must be List

        public IEnumerable<Room> Rooms { get; set; }
    }
}
