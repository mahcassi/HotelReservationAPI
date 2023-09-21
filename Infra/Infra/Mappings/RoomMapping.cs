using Entity.Entity;
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

            builder.HasOne(b => b.Reservation)
               .WithOne(h => h.Room);

            builder.HasMany(h => h.RoomAmenities)
              .WithOne(ha => ha.Room)
              .HasForeignKey(ha => ha.RoomId);

            builder.ToTable("Rooms"); 
        }
    }
}