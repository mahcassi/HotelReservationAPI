using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int NumberPeople { get; set; }
        public int PaymentStatus { get; set; }
        public Guid GuestId { get; set; }
        public Guest Guest { get; set; }
        public Guid RoomId { get; set; }
        public Room Room { get; set; }
        public Guid PaymentReservationId { get; set; }
        public PaymentReservation PaymentReservation { get; set; }
    }
}
