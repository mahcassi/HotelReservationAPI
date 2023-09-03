﻿using Infra.Interfaces.Repository;
using Entity.Entity;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Infra.Repository
{
    public class HotelRepository : BaseRepository<Hotel>, IHotelRepository
    {

        public HotelRepository(MyDbContext context) : base(context)
        {
        }

        public async Task<Hotel> GetHotelAddressAmenities(int id)
        {
            var result = await Db.Hotels.AsNoTracking()
                .Include(c => c.AddressHotel)
                .Include(c => c.HotelAmenities)
                .ThenInclude(c => c.AmenityHotel)
                .FirstOrDefaultAsync(c => c.Id == id);

            return result;
        }

        public async Task<bool> AssociationAmenityHotel(int hotelId, int amenityId)
        {
            var amentiesExist = Db.HotelAmenities.Where(ha => ha.HotelId == hotelId && ha.AmenityId == amenityId).ToList();

            if (!amentiesExist.Any())
            {
                var hotelAmenity = new HotelAmenity
                {
                    HotelId = hotelId,
                    AmenityId = amenityId
                };

                Db.HotelAmenities.Add(hotelAmenity);
                await SaveChanges();
                return true; // Associação adicionada com sucesso
            }

            return false; // A associação já existe
        }

        public async Task UpdateAssociationAmenityHotel(int hotelId, IEnumerable<int> newAmenityIds)
        {
            var currentAmenityIds = await Db.HotelAmenities
                                            .Where(ha => ha.HotelId == hotelId)
                                            .Select(ha => ha.AmenityId)
                                            .ToListAsync();

            var amenitiesToRemove = currentAmenityIds.Except(newAmenityIds).ToList();
            var amenitiesToAdd = newAmenityIds.Except(currentAmenityIds).ToList();

            if (amenitiesToRemove.Any())
            {
                var amenitiesToRemoveEntities = Db.HotelAmenities
                    .Where(ha => ha.HotelId == hotelId && amenitiesToRemove.Contains(ha.AmenityId))
                    .ToList();

                Db.HotelAmenities.RemoveRange(amenitiesToRemoveEntities);
            }

            foreach (var amenityId in amenitiesToAdd)
            {
                var hotelAmenity = new HotelAmenity
                {
                    HotelId = hotelId,
                    AmenityId = amenityId
                };

                Db.HotelAmenities.Add(hotelAmenity);
            }

            await SaveChanges();
        }
    }
}