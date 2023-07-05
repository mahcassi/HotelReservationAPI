using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class PaymentReservation
    {
        public int Id { get; set; }
        public int PaymentMethod { get; set; }
        public int NumberCreditCard { get; set; }
        public double AmountPaid { get; set; }
        public int IdReservation { get; set; }
    }
}
