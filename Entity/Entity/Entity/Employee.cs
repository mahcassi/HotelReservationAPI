using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Employee
    {
        public int Guid { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public AddressHotel AddressHotel { get; set; }
        public string JobTitle { get; set; }

        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
