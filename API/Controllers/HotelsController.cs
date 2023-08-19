using API.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Domain.Interfaces.Repository;
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
            var hotel = _mapper.Map<IEnumerable<HotelDTO>>(await _hotelRepository.GetAll());
            return hotel;
        }

        [HttpPost]
        public async Task<ActionResult<HotelDTO>> Adicionar(HotelDTO hotel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _hotelService.Add(_mapper.Map<Hotel>(hotel));

            return CustomResponse(hotel);
        }

    }
}
