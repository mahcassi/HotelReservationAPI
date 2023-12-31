﻿using Entity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class HotelMapping : IEntityTypeConfiguration<Hotel>
    {
        public void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.CNPJ)
               .IsRequired()
               .HasColumnType("varchar(14)");


            builder.Property(p => p.PhoneNumber)
               .IsRequired()
               .HasColumnType("varchar(14)");

            builder.Property(p => p.PhoneNumber)
              .IsRequired()
              .HasColumnType("varchar(200)");

            builder.HasOne(b => b.AddressHotel)
            .WithOne(h => h.Hotel)
            .HasForeignKey<AddressHotel>(h => h.HotelId);

            builder.HasMany(h => h.HotelAmenities)
              .WithOne(ha => ha.Hotel)
              .HasForeignKey(ha => ha.HotelId);

            builder.HasMany(h => h.Rooms)
              .WithOne(ha => ha.Hotel)
              .HasForeignKey(ha => ha.HotelId);
        }
    }
}