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
        }
    }
}
