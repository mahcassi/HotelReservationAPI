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
    public class HotelService : BaseService, IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        private readonly IAddressHotelRepository _addressHotelRepository;
        private readonly MyDbContext _dbContext;

        public HotelService(IHotelRepository hotelRepository, INotifier notify, MyDbContext dbContext, IAddressHotelRepository addressHotelRepository) : base(notify)
        {
            _hotelRepository = hotelRepository;
            _dbContext = dbContext;
            _addressHotelRepository = addressHotelRepository;
        }

        public async Task<bool> Add(Hotel hotel)
        {
            if (ExecuteValidation(new HotelValidation(), hotel)) return false;

            if (_hotelRepository.Search(h => h.CNPJ == hotel.CNPJ).Result.Any())
            {
                Notify("Já existe um hotel com este CNPJ informado.");
                return false;
            }

            await _hotelRepository.Add(hotel);
            return true;
        }



        public async Task<bool> Remove(int id)
        {
            if (_hotelRepository.GetHotelAddressAmenitiesRoom(id).Result.Rooms.Any())
            {
                Notify("O Hotel possui quartos cadastrados!");
                return false;
            }

            var addressHotel = await _addressHotelRepository.GetAddressByHotel(id);

            if (addressHotel != null)
            {
                await _addressHotelRepository.Remove(addressHotel.Id);
            }

            await _hotelRepository.RemoveAssociationAmenityHotel(id);
            await _hotelRepository.Remove(id);

            return true;
        }

        public async Task<bool> Update(Hotel hotel)
        {
            if (ExecuteValidation(new HotelValidation(), hotel)) return false;

            if (_hotelRepository.Search(h => h.CNPJ == hotel.CNPJ && h.Id != hotel.Id).Result.Any())
            {
                Notify("Já existe um hotel com este CNPJ informado.");
                return false;
            }

            await _hotelRepository.Update(hotel);
            return true;
        }

        public async Task<bool> UpdateHotelWithAmenities(Hotel hotel, IEnumerable<int> amenityIds)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    bool isHotelUpdated = await Update(hotel);

                    if (isHotelUpdated)
                    {
                        await _hotelRepository.UpdateAssociationAmenityHotel(hotel.Id, amenityIds);
                        transaction.Commit();
                        return true;
                    }
                    else
                    {
                        Notify("Hotel não foi atualizado. Comodidades não foram associadas.");
                        return false;
                    }
                } catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
            }
                
        }

        public async Task<bool> AddHotelWithAmenities(Hotel hotel, IEnumerable<int> amenityIds)
        {
            bool isHotelAdded = await Add(hotel);

            if (isHotelAdded)
            {
                foreach (var amenityId in amenityIds)
                {
                    await _hotelRepository.AssociationAmenityHotel(hotel.Id, amenityId);
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
            _hotelRepository?.Dispose();
        }

    }
}
