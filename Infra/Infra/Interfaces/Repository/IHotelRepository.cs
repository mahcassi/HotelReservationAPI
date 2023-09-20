using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces.Repository
{
    public interface IHotelRepository : IBaseRepository<Hotel>
    {
        Task<Hotel> GetHotelAddressAmenitiesRoom(int id);

        Task<List<Hotel>> GetHotels();

        Task<bool> AssociationAmenityHotel(int hotelId, int amenityId);

        Task UpdateAssociationAmenityHotel(int hotelId, IEnumerable<int> newAmenityIds);

        Task RemoveAssociationAmenityHotel(int hotelId);
    }
}
