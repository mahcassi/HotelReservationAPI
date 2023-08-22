using Entity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            builder.HasOne(b => b.AddressHotel)
            .WithOne(h => h.Hotel)
            .HasForeignKey<AddressHotel>(h => h.HotelId);

            builder.HasMany(b => b.Amenities)
            .WithOne(h => h.Hotel)
            .HasForeignKey(h => h.HotelId);
        }
    }
}