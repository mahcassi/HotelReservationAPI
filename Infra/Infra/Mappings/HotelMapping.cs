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
    public class HotelAmenitiesMapping : IEntityTypeConfiguration<HotelAmenities>
    {
        public void Configure(EntityTypeBuilder<HotelAmenities> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");


            builder.HasOne(b => b.Hotel)
              .WithMany(h => h.Amenities)
              .HasForeignKey(f => f.HotelId);
        }

    }
}
