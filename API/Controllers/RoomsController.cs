using API.DTO;
using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using Infra.Interfaces.Repository;
using Infra.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : MainController
    {
        private readonly IMapper _mapper;
        private readonly IRoomRepository _roomRepository;
        private readonly IRoomService _roomService;
        private readonly INotifier _notifier;

        public RoomsController(INotifier notifier, IMapper mapper, IRoomRepository roomRepository, IRoomService roomService) : base(notifier)
        {
            _mapper = mapper;
            _roomRepository = roomRepository;
            _roomService = roomService;
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<RoomDTO>> ObterPorId(int id)
        {
            var room = await ObterRoomHotel(id);

            if (room == null) return NotFound();

            return Ok(room);
        }

        [NonAction]
        private async Task<RoomDTO> ObterRoomHotel(int id)
        {
            return _mapper.Map<RoomDTO>(await _roomRepository.GetRoomHotel(id));
        }

    }
}
