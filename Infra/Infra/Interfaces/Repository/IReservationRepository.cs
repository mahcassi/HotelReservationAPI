using Entity.Entity;

namespace Infra.Interfaces.Repository
{
    public interface IReservationRepository : IBaseRepository<Reservation>
    {
        Task<Reservation> GetReservationGuestRoom(int id);
    }
}
