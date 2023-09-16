using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces.Repository
{
    public interface IAddressHotelRepository : IBaseRepository<AddressHotel>
    {
        Task<AddressHotel> GetAddressByHotel(int hotelId);
    }
}
