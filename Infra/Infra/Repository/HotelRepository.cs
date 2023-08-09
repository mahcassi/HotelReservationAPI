using Domain.Interfaces.Repository;
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
    public class HotelRepository : BaseRepository<Hotel>, IHotelRepository
    {

        public HotelRepository(MyDbContext context) : base(context)
        {
        }

        public async Task<Hotel> GetHotelAddress(int id)
        {
            return await Db.Hotels.AsNoTracking()
                .Include(c => c.AddressHotel)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Hotel> GetHotelRooms(int id)
        {
            return await Db.Hotels.AsNoTracking()
                .Include(c => c.Rooms)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
