using Infra.Interfaces.Repository;
using Entity.Entity;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
    {
        public ReservationRepository(MyDbContext context) : base(context)
        {
        }

        public async Task<Reservation> GetReservationGuestRoom(int id)
        {
            return await Db.Reservations.AsNoTracking()
                .Include(c => c.Guest)
                .Include(c => c.Room)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
