using API.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Infra.Interfaces.Repository;
using Domain.Interfaces.Services;
using Domain.Interfaces;
using Entity.Entity;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IHotelRepository _hotelRepository;
        private readonly IHotelService _hotelService;
        private readonly INotifier _notifier;

        public HotelsController(IHotelRepository hotelRepository, IMapper mapper, IHotelService hotelService, INotifier notifier) : base(notifier)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
            _hotelService = hotelService;
        }

        [HttpGet]
        public async Task<IEnumerable<HotelDTO>> ObterTodos()
        {
            var hotel = _mapper.Map<IEnumerable<HotelDTO>>(await _hotelRepository.GetHotels());
            return hotel;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<HotelResponseDTO>> ObterPorId(int id)
        {
            var hotel = await ObterHotelRoomEndereco(id);

            if (hotel == null) return NotFound();

            var hotelDTO = new HotelResponseDTO
            {
                Id = hotel.Id,
                Name = hotel.Name,
                CNPJ = hotel.CNPJ,
                PhoneNumber = hotel.PhoneNumber,
                AddressHotel = hotel.AddressHotel,
                AmenityHotel = hotel.HotelAmenities.Select(x => x.AmenityHotel).ToList(),
                Description = hotel.Description
            };

            return Ok(hotelDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<HotelResponseDTO>> Excluir(int id)
        {
            var hotel = await ObterHotelRoomEndereco(id);

            if (hotel == null) return NotFound();

            await _hotelService.Remove(id);

            return CustomResponse();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<HotelResponseDTO>> AtualizarHotel(int id, HotelRequestDTO hotel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _hotelService.UpdateHotelWithAmenities(_mapper.Map<Hotel>(hotel), hotel.AmenitiesIds);

            return CustomResponse(hotel);
        }

        [HttpPost]
        public async Task<ActionResult<HotelRequestDTO>> Adicionar(HotelRequestDTO hotel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _hotelService.AddHotelWithAmenities(_mapper.Map<Hotel>(hotel), hotel.AmenitiesIds);

            return CustomResponse(hotel);
        }

        [NonAction]
        private async Task<HotelDTO> ObterHotelRoomEndereco(int id)
        {
            return _mapper.Map<HotelDTO>(await _hotelRepository.GetHotelAddressAmenitiesRoom(id));
        }

    }
}
