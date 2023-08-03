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
            if (ExecuteValidation(new HotelValidation(), hotel)) return false;

            if(_repository.Search(h => h.CNPJ == hotel.CNPJ).Result.Any())
            {
                Notify("Já existe um fornecedor com este documento informado.");
                return false;
            }

            await _repository.Add(hotel);
            return true;
        }

        public Task Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Hotel hotel)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
