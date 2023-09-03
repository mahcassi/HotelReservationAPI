using Entity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class HotelAmenitiesMapping : IEntityTypeConfiguration<HotelAmenity>
    {
        public void Configure(EntityTypeBuilder<HotelAmenity> builder)
        {
            builder.HasKey(ha => new { ha.HotelId, ha.AmenityId });

            builder.HasOne(ha => ha.Hotel)
                .WithMany(h => h.HotelAmenities)
                .HasForeignKey(ha => ha.HotelId);

            builder.HasOne(ha => ha.AmenityHotel)
                .WithMany(a => a.HotelAmenities)
                .HasForeignKey(ha => ha.AmenityId);
        }
    }
}