﻿using Domain.Interfaces.Repository;
using Entity.Entity;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class HotelRepository : BaseRepository<Hotel>, IHotelRepository
    {

        public HotelRepository(MyDbContext context) : base(context)
        {
        }

        public async Task<Hotel> GetHotelAddressAmenities(int id)
        {
            return await Db.Hotels.AsNoTracking()
                .Include(c => c.AddressHotel)
                .Include(c => c.Amenities)
                .FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
