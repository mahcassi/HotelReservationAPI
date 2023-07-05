using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int NumberPeople { get; set; }
        public int PaymentStatus { get; set; }

        public int IdHotel { get; set; }
        public int IdGuest { get; set; }
    }
}
