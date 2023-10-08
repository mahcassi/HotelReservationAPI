using Entity.Entity;

namespace Domain.Interfaces.Services
{
    public interface IRoomService : IDisposable
    {
        Task<bool> Add(Room room);
        Task<bool> Update(Room room);
        Task<bool> Remove(int id);
        Task<List<Room>> SearchRooms(string number);
        Task<bool> AddRoomWithAmenities(Room room, IEnumerable<int> amenityIds);
        Task<bool> UpdateRoomWithAmenities(Room room, IEnumerable<int> amenityIds);
    }
}
