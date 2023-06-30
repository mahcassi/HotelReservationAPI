using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomType { get; set; } // must be enum
        public double Price { get; set; }
        public bool Availability { get; set; }
    }
}
