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
    public class GuestMapping : IEntityTypeConfiguration<Guest>
    {
        public void Configure(EntityTypeBuilder<Guest> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(b => b.Telephone)
               .IsRequired()
               .HasColumnType("varchar(20)");

            builder.Property(b => b.Cpf)
               .IsRequired()
               .HasColumnType("varchar(11)");

            builder.HasMany(b => b.Reservations)
                .WithOne(h => h.Guest)
                .HasForeignKey(f => f.GuestId);

            builder.ToTable("Guest");
        }

    }
}
