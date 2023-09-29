using Microsoft.AspNetCore.Identity;

namespace Entity.Entity
{
    public class Guest : IdentityUser
    {
        public string Name { get; set; }
        public string Telephone { get; set; }
        public string Cpf { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
