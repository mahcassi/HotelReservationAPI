using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class HotelResponseDTO
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string CNPJ { get; set; }

        public string PhoneNumber { get; set; }

        public string Description { get; set; }

        public AddressHotelDTO AddressHotel { get; set; }
        public IEnumerable<AmenityHotelDTO> AmenityHotel { get; set; }
    }
}
