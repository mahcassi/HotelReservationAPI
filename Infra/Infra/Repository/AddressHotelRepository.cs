using Entity.Entity;
using Infra.Context;
using Infra.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

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
