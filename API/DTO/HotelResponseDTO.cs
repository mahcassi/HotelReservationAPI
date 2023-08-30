using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class HotelResponseDTO
    {
        [Key]
        public int Id { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        //[StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Name { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        //[StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 11)]
        public string CNPJ { get; set; }

        public AddressHotelDTO AddressHotel { get; set; }
        public IEnumerable<AmenityHotelDTO> AmenityHotel { get; set; }
    }
}
