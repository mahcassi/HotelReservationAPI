using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IRoomService : IDisposable
    {
        Task<bool> Add(Room room);
        Task<bool> Update(Room room);
        Task Remove(int id);
    }
}
