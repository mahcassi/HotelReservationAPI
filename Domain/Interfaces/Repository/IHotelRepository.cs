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
        Task<Hotel> GetHotelAddressAmenities(int id);
        Task AssociationAmenityHotel(int hotelId, int amenityId);

        Task UpdateAssociationAmenityHotel(int hotelId, int amenityId);
    }
}
