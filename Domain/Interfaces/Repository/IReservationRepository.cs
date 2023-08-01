using Entity.Entity;

namespace Domain.Interfaces.Repository
{
    public interface IReservationRepository : IBaseRepository<Reservation>
    {
        Task<Reservation> GetReservationGuestRoom(int id);
    }
}
