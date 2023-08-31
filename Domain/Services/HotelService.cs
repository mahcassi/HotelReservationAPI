using Domain.Interfaces;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Entity.Entity;
using Entity.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class HotelService : BaseService, IHotelService
    {
        private readonly IHotelRepository _repository;

        public HotelService(IHotelRepository repository, INotifier notify) : base(notify)
        {
            _repository = repository;
        }

        public async Task<bool> Add(Hotel hotel)
        {

            if(_repository.Search(h => h.CNPJ == hotel.CNPJ).Result.Any())
            {
                Notify("Já existe um hotel com este CNPJ informado.");
                return false;
            }

            await _repository.Add(hotel);
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

        public async Task<bool> Update(Hotel hotel)
        {
            //if (ExecuteValidation(new HotelValidation(), hotel)) return false;

            if (_repository.Search(h => h.CNPJ == hotel.CNPJ && h.Id != hotel.Id).Result.Any())
            {
                Notify("Já existe um hotel com este CNPJ informado.");
                return false;
            }

            await _repository.Update(hotel);
            return true;
        }

        public async Task<bool> AtualizarHotelComAmenities(Hotel hotel, IEnumerable<int> amenityIds)
        {
            bool isHotelUpdated = await Update(hotel);

            if (isHotelUpdated)
            {
                foreach (var amenityId in amenityIds)
                {
                    await _repository.UpdateAssociationAmenityHotel(hotel.Id, amenityId);
                }
                return true;
            }
            else
            {
                Notify("Hotel não foi atualizado. Comodidades não foram associadas.");
                return false;
            }
        }

        public async Task<bool> AdicionarHotelComAmenities(Hotel hotel, IEnumerable<int> amenityIds)
        {
            bool isHotelAdded = await Add(hotel);

            if (isHotelAdded)
            {
                foreach (var amenityId in amenityIds)
                {
                    await _repository.AssociationAmenityHotel(hotel.Id, amenityId);
                }
                return true;
            }
            else
            {
                Notify("Hotel não foi adicionado. Comodidades não foram associadas.");
                return false;
            }
        }

        public void Dispose()
        {
            _repository?.Dispose();
        }

    }
}
