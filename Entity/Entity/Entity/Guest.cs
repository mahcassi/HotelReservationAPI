using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Guest
    {
        public int Guid { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public string Cpf { get; set; }

        public IEnumerable<Reservation> Reservations { get; set; }
        public IEnumerable<PaymentReservation> PaymentReservations { get; set; }
    }
}
