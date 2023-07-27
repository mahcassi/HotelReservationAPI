using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repository
{
    public interface IRoomRepository : IBaseRepository<Room>
    {
        Task<Room> GetRoomHotel(int id);
    }
}
