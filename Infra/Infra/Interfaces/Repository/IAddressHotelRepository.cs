using Entity.Entity;

namespace Infra.Interfaces.Repository
{
    public interface IAddressHotelRepository : IBaseRepository<AddressHotel>
    {
        Task<AddressHotel> GetAddressByHotel(int hotelId);
    }
}
