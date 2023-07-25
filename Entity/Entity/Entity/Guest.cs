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
