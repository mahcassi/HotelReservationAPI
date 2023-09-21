using Entity.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infra.Mappings
{
    public class RoomAmenitiesMapping : IEntityTypeConfiguration<RoomAmenity>
    {
        public void Configure(EntityTypeBuilder<RoomAmenity> builder)
        {
            builder.HasKey(ha => new { ha.RoomId, ha.AmenityId });

            builder.HasOne(ha => ha.Room)
                .WithMany(h => h.RoomAmenities)
                .HasForeignKey(ha => ha.RoomId);

            builder.HasOne(ha => ha.AmenityRoom)
                .WithMany(a => a.RoomAmenities)
                .HasForeignKey(ha => ha.AmenityId);
        }
    }
}
