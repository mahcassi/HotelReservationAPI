using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class AdressGuest : AddressEntity
    {
        public Guid GuestId { get; set; }
        public Guest Guest { get; set; }
    }
}
