using Entity.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Mappings
{
    public class AmenityHotelMapping : IEntityTypeConfiguration<AmenityHotel>
    {
        public void Configure(EntityTypeBuilder<AmenityHotel> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.HasMany(h => h.HotelAmenities)
              .WithOne(ha => ha.AmenityHotel)
              .HasForeignKey(ha => ha.AmenityId); 
        }
    }
}
