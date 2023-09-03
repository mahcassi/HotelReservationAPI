using Entity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class ReservationMapping : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(b => b.CheckIn)
                .IsRequired()
                .HasColumnType("DateTime");

            builder.Property(b => b.CheckOut)
                .IsRequired()
                .HasColumnType("DateTime");

            builder.Property(b => b.NumberPeople)
                .IsRequired()
                .HasColumnType("int");

            builder.HasOne(b => b.Guest)
                .WithMany(h => h.Reservations)
                .HasForeignKey(b => b.GuestId)
                .IsRequired();

            builder.HasOne(b => b.Room)
                .WithOne(h => h.Reservation)
                .IsRequired();

            builder.ToTable("Reservations");
        }
    }
}
