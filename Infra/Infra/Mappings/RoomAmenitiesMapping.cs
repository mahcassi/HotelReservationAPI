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
    public class RoomAmenitiesMapping : IEntityTypeConfiguration<RoomAmenities>
    {
        public void Configure(EntityTypeBuilder<RoomAmenities> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.HasOne(b => b.Room)
              .WithMany(h => h.Amenities)
              .HasForeignKey(f => f.RoomId);
        }

    }
}
