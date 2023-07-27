using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Entity
{
    public class HotelAmenities : BaseEntity
    {
        public string Name { get; set; }
        public int HotelId { get; set; }
        public Hotel Hotel { get; set; }

    }
}
