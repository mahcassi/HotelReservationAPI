﻿using API.DTO;
using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Services;
using Domain.Services;
using Entity.Entity;
using Entity.Enums;
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
        private readonly IHotelRepository _hotelRepository;
        private readonly IRoomService _roomService;
        private readonly INotifier _notifier;

        public RoomsController(INotifier notifier, IMapper mapper, IRoomRepository roomRepository, IRoomService roomService, IHotelRepository hotelRepository) : base(notifier)
        {
            _mapper = mapper;
            _roomRepository = roomRepository;
            _roomService = roomService;
            _hotelRepository = hotelRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<RoomDTO>> ObterTodos()
        {
            var rooms = await _roomRepository.GetAll();

            var roomDTOs = new List<RoomDTO>();

            foreach (var room in rooms)
            {
                var hotelAddress = _mapper.Map<HotelDTO>(await _hotelRepository.GetHotelAddressAmenitiesRoom(room.HotelId));

                var roomDTO = new RoomDTO
                {
                    Id = room.Id,
                    RoomType = room.RoomType.GetDescriptionFromValue(),
                    Price = room.Price,
                    Number = room.Number,
                    Availability = room.Availability,
                    Size = room.Size,
                    HotelId = room.HotelId,
                    HotelAddress = hotelAddress.AddressHotel
                };

                roomDTOs.Add(roomDTO);

            }

            return roomDTOs;
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<RoomDTO>> ObterPorId(int id)
        {
            var room = await ObterRoomHotel(id);

            if (room == null) return NotFound();

            var roomDTO = new RoomDTO
            {
                Id = room.Id,
                RoomType = room.RoomType.GetDescriptionFromValue(),
                Price = room.Price,
                Number = room.Number,
                Availability = room.Availability,
                Size = room.Size,
                HotelId = room.HotelId,
            };

            return Ok(roomDTO);
        }

        [HttpGet("teste")]
        public async Task<IActionResult> SearchRooms([FromQuery] string number)
        {
            var rooms = await _roomService.SearchRooms(number);
            return Ok(rooms);
        }

        [HttpPost]
        public async Task<ActionResult<RoomRequestDTO>> Adicionar(RoomRequestDTO room)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _roomService.AddRoomWithAmenities(_mapper.Map<Room>(room), room.AmenitiesIds);

            return CustomResponse(room);
        }

        [NonAction]
        private async Task<Room> ObterRoomHotel(int id)
        {
            return await _roomRepository.GetRoomHotel(id);
        }
    }
}
