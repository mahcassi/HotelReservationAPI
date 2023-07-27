using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Guest : BaseEntity
    {
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Cpf { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
