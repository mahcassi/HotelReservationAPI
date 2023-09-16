using Entity.Entity;
using Infra.Context;
using Infra.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class AddressHotelRepository : BaseRepository<AddressHotel>, IAddressHotelRepository
    {
        public AddressHotelRepository(MyDbContext context) : base(context)
        {
        }

        public async Task<AddressHotel> GetAddressByHotel(int hotelId)
        {
            return await Db.AddressHotels.AsNoTracking().FirstOrDefaultAsync(h => h.HotelId == hotelId);
        }
    }
}
