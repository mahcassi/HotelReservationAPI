using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class ApplicationUser : IdentityUser
    {
        public string Cellphone { get; set; }
        public int UserType { get; set; }
    }
}
