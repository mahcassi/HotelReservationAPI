using Entity.Entity;
using Infra.Context;
using Infra.Interfaces.Repository;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class HotelRepository : BaseRepository<Hotel>, IHotelRepository
    {

        public HotelRepository(MyDbContext context) : base(context)
        {
        }



        public async Task<Hotel> GetHotelAddressAmenitiesRoom(int id)
        {
            var result = await Db.Hotels.AsNoTracking()
                .Include(c => c.AddressHotel)
                .Include(c => c.Rooms)
                .Include(c => c.HotelAmenities)
                .ThenInclude(c => c.AmenityHotel)
                .FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task<List<Hotel>> GetHotels()
        {
            var result = await Db.Hotels.AsNoTracking()
                .Include(c => c.AddressHotel)
                .ToListAsync();

            return result;
        }

        public async Task<bool> AssociationAmenityHotel(int hotelId, int amenityId)
        {
            var amentiesExist = Db.HotelAmenities.Where(ha => ha.HotelId == hotelId && ha.AmenityId == amenityId).ToList();

            if (!amentiesExist.Any())
            {
                var hotelAmenity = new HotelAmenity
                {
                    HotelId = hotelId,
                    AmenityId = amenityId
                };

                Db.HotelAmenities.Add(hotelAmenity);
                await SaveChanges();
                return true; // Associação adicionada com sucesso
            }

            return false; // A associação já existe
        }

        public async Task UpdateAssociationAmenityHotel(int hotelId, IEnumerable<int> newAmenityIds)
        {
            var currentAmenityIds = await Db.HotelAmenities
                                            .Where(ha => ha.HotelId == hotelId)
                                            .Select(ha => ha.AmenityId)
                                            .ToListAsync();

            var amenitiesToRemove = currentAmenityIds.Except(newAmenityIds).ToList();
            var amenitiesToAdd = newAmenityIds.Except(currentAmenityIds).ToList();

            if (amenitiesToRemove.Any())
            {
                var amenitiesToRemoveEntities = Db.HotelAmenities
                    .Where(ha => ha.HotelId == hotelId && amenitiesToRemove.Contains(ha.AmenityId))
                    .ToList();

                Db.HotelAmenities.RemoveRange(amenitiesToRemoveEntities);
            }

            foreach (var amenityId in amenitiesToAdd)
            {
                var hotelAmenity = new HotelAmenity
                {
                    HotelId = hotelId,
                    AmenityId = amenityId
                };

                Db.HotelAmenities.Add(hotelAmenity);
            }

            await SaveChanges();
        }

        public async Task RemoveAssociationAmenityHotel(int hotelId)
        {
            var amenitiesToRemoveEntities = Db.HotelAmenities
                   .Where(ha => ha.HotelId == hotelId).ToList();

            Db.HotelAmenities.RemoveRange(amenitiesToRemoveEntities);

            await SaveChanges();
        }
    }
}