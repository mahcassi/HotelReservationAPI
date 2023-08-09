using API.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Domain.Interfaces.Repository;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IHotelRepository _hotelRepository;

        public HotelsController(IHotelRepository hotelRepository, IMapper mapper)
        {
            _hotelRepository = hotelRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<HotelDTO>> ObterTodos()
        {
            var hotel = _mapper.Map<IEnumerable<HotelDTO>>(await _hotelRepository.GetAll());
            return hotel;
        }
    }
}
