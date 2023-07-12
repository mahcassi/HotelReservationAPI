using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class PaymentReservation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PaymentMethod { get; set; }
        public int NumberCreditCard { get; set; }
        public double AmountPaid { get; set; }
        public int ReservationId { get; set; }
        public Reservation Reservation { get; set; }
    }
}
