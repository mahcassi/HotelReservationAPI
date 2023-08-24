﻿using Entity.Entity;
using System.ComponentModel.DataAnnotations;

namespace API.DTO
{
    public class HotelAmenitiesDTO
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int AmenityId { get; set; }
        public HotelDTO Hotel { get; set; }
        public AmenityHotelDTO AmenityHotel { get; set; }
    }
}
