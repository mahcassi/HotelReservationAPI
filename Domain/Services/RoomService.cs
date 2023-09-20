using Domain.Interfaces;
using Infra.Interfaces.Repository;
using Domain.Interfaces.Services;
using Entity.Entity;
using Entity.Validations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infra.Context;

namespace Domain.Services
{
    public class RoomService : BaseService, IRoomService
    {
        private readonly IRoomRepository _repository;

        public RoomService(IRoomRepository repository, INotifier notify) : base(notify)
        {
            _repository = repository;
        }

        public async Task<bool> Add(Room room)
        {

            if(_repository.Search(r => r.Number == room.Number).Result.Any())
            {
                Notify("Já existe um quarto com este número informado.");
                return false;
            }

            await _repository.Add(room);
            return true;
        }

        public async Task Remove(int id)
        {
            //if (_repository.GetHotelRooms(id).Result.Rooms.Any())
            //{
            //    Notify("O fornecedor possui produtos cadastrados!");
            //    return false;
            //}
        }

        public async Task<bool> Update(Room room)
        {
            //if (ExecuteValidation(new HotelValidation(), hotel)) return false;

            if (_repository.Search(r => r.Number == room.Number && r.Id != room.Id).Result.Any())
            {
                Notify("Já existe um quarto com este número informado.");
                return false;
            }

            await _repository.Update(room);
            return true;
        }

        public async Task<List<Room>> SearchRooms(string number)
        {
            return await _repository.SearchRoomByType(number);
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }
    }
}
