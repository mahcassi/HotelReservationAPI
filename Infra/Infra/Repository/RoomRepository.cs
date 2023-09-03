using Infra.Interfaces.Repository;
using Entity.Entity;
using Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(MyDbContext context) : base(context)
        {
        }

        public async Task<Room> GetRoomHotel(int id)
        {
            return await Db.Rooms.AsNoTracking()
                .Include(c => c.Hotel)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
