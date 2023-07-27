﻿using Entity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class RoomMapping : IEntityTypeConfiguration<Room>
    {
        public void Configure(EntityTypeBuilder<Room> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.RoomType)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.Property(b => b.Price)
                .IsRequired()
                .HasColumnType("decimal(20, 2)");

            builder.Property(b => b.Availability)
                .IsRequired()
                .HasColumnType("BIT");

            builder.Property(b => b.Size)
                .IsRequired()
                .HasColumnType("varchar(20)");

            builder.HasMany(b => b.Amenities)
                .WithOne(h => h.Room)
                .HasForeignKey(f => f.RoomId);

            builder.HasOne(b => b.Reservation)
               .WithOne(h => h.Room);

            builder.HasOne(b => b.Hotel) // Cada quarto tem um hotel (relacionamento um-para-um)
               .WithMany(h => h.Rooms) // Cada hotel pode ter muitos quartos
               .HasForeignKey(b => b.HotelId) // Chave estrangeira para HotelId na entidade Room
               .IsRequired();

            builder.ToTable("Rooms"); 
        }
    }
}