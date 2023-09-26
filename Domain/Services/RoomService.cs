using Domain.Interfaces;
using Domain.Interfaces.Services;
using Entity.Entity;
using Infra.Context;
using Infra.Interfaces.Repository;

namespace Domain.Services
{
    public class RoomService : BaseService, IRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly MyDbContext _dbContext;

        public RoomService(IRoomRepository repository, INotifier notify, MyDbContext dbContext) : base(notify)
        {
            _roomRepository = repository;
            _dbContext = dbContext;
        }

        public async Task<bool> Add(Room room)
        {

            if(_roomRepository.Search(r => r.Number == room.Number).Result.Any())
            {
                Notify("Já existe um quarto com este número informado.");
                return false;
            }

            await _roomRepository.Add(room);
            return true;
        }

        public async Task Remove(int id)
        {
            //if (_roomRepository.GetroomRooms(id).Result.Rooms.Any())
            //{
            //    Notify("O fornecedor possui produtos cadastrados!");
            //    return false;
            //}
        }

        public async Task<bool> Update(Room room)
        {
            //if (ExecuteValidation(new roomValidation(), room)) return false;

            if (_roomRepository.Search(r => r.Number == room.Number && r.Id != room.Id).Result.Any())
            {
                Notify("Já existe um quarto com este número informado.");
                return false;
            }

            await _roomRepository.Update(room);
            return true;
        }

        public async Task<List<Room>> SearchRooms(string number)
        {
            return await _roomRepository.SearchRoomByType(number);
        }

        public async Task<bool> UpdateRoomWithAmenities(Room room, IEnumerable<int> amenityIds)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    bool isRoomUpdated = await Update(room);

                    if (isRoomUpdated)
                    {
                        await _roomRepository.UpdateAssociationAmenityRoom(room.Id, amenityIds);
                        transaction.Commit();
                        return true;
                    }
                    else
                    {
                        Notify("Quarto não foi atualizado. Comodidades não foram associadas.");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
            }

        }

        public async Task<bool> AddRoomWithAmenities(Room room, IEnumerable<int> amenityIds)
        {
            bool isRoomAdded = await Add(room);

            if (isRoomAdded)
            {
                foreach (var amenityId in amenityIds)
                {
                    await _roomRepository.AssociationAmenityRoom(room.Id, amenityId);
                }
                return true;
            }
            else
            {
                Notify("Quarto não foi adicionado. Comodidades não foram associadas.");
                return false;
            }
        }

        public void Dispose()
        {
            _roomRepository?.Dispose();
        }
    }
}
