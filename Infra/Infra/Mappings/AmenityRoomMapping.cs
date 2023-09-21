using Entity.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infra.Mappings
{
    public class AmenityRoomMapping : IEntityTypeConfiguration<AmenityRoom>
    {
        public void Configure(EntityTypeBuilder<AmenityRoom> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.HasMany(h => h.RoomAmenities)
              .WithOne(ha => ha.AmenityRoom)
              .HasForeignKey(ha => ha.AmenityId);
        }
    }
}