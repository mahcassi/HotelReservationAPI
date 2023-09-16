﻿using Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IHotelService : IDisposable
    {
        Task<bool> Add(Hotel hotel);
        Task<bool> Update(Hotel hotel);
        Task<bool> Remove(int id);
        Task<bool> AddHotelWithAmenities(Hotel hotel, IEnumerable<int> amenityIds);
        Task<bool> UpdateHotelWithAmenities(Hotel hotel, IEnumerable<int> amenityIds);
    }
}
