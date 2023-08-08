using Entity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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