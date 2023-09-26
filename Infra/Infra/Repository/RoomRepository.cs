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

        public async Task<List<Room>> SearchRoomByType(string number)
        {
            var query = Db.Rooms.AsQueryable();

            if (!string.IsNullOrEmpty(number))
            {
                query = query.Where(p => p.Number.Contains(number));
            }

            return await query.ToListAsync();
        }

        public async Task<bool> AssociationAmenityRoom(int roomId, int amenityId)
        {
            var amentiesExist = Db.RoomAmenities.Where(ha => ha.RoomId == roomId && ha.AmenityId == amenityId).ToList();

            if (!amentiesExist.Any())
            {
                var roomAmenity = new RoomAmenity
                {
                    RoomId = roomId,
                    AmenityId = amenityId
                };

                Db.RoomAmenities.Add(roomAmenity);
                await SaveChanges();
                return true; // Associação adicionada com sucesso
            }

            return false; // A associação já existe
        }

        public async Task UpdateAssociationAmenityRoom(int roomId, IEnumerable<int> newAmenityIds)
        {
            var currentAmenityIds = await Db.RoomAmenities
                                            .Where(ha => ha.RoomId == roomId)
                                            .Select(ha => ha.AmenityId)
                                            .ToListAsync();

            var amenitiesToRemove = currentAmenityIds.Except(newAmenityIds).ToList();
            var amenitiesToAdd = newAmenityIds.Except(currentAmenityIds).ToList();

            if (amenitiesToRemove.Any())
            {
                var amenitiesToRemoveEntities = Db.RoomAmenities
                    .Where(ha => ha.RoomId == roomId && amenitiesToRemove.Contains(ha.AmenityId))
                    .ToList();

                Db.RoomAmenities.RemoveRange(amenitiesToRemoveEntities);
            }

            foreach (var amenityId in amenitiesToAdd)
            {
                var roomAmenity = new RoomAmenity
                {
                    RoomId = roomId,
                    AmenityId = amenityId
                };

                Db.RoomAmenities.Add(roomAmenity);
            }

            await SaveChanges();
        }

        public async Task RemoveAssociationAmenityRoom(int roomId)
        {
            var amenitiesToRemoveEntities = Db.RoomAmenities
                   .Where(ha => ha.RoomId == roomId).ToList();

            Db.RoomAmenities.RemoveRange(amenitiesToRemoveEntities);

            await SaveChanges();
        }

    }
}
