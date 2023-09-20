using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces.Repository
{
    public interface IRoomRepository : IBaseRepository<Room>
    {
        Task<Room> GetRoomHotel(int id);

        Task<List<Room>> SearchRoomByType(string number);
    }
}
