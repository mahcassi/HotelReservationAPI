using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IHotelRepository : IBaseRepository<Hotel>
    {
        Task<Hotel> GetHotelAddress(int id);

        Task<Hotel> GetHotelRooms(int id);
    }
}
