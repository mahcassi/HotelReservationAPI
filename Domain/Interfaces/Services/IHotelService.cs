using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IHotelService : IDisposable
    {
        Task<bool> Add(Hotel hotel);
        Task Update(Hotel hotel);
        Task Remove(int id);
    }
}
