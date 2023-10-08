using Entity.Entity;

namespace Infra.Interfaces.Repository
{
    public interface IRoomRepository : IBaseRepository<Room>
    {
        Task<Room> GetRoomHotel(int id);

        Task<Room> GetRoomAmenitiesReservation(int id);

        Task<List<Room>> SearchRoomByType(string number);

        Task<bool> AssociationAmenityRoom(int roomId, int amenityId);

        Task UpdateAssociationAmenityRoom(int roomId, IEnumerable<int> newAmenityIds);

        Task RemoveAssociationAmenityRoom(int roomId);
    }
}
