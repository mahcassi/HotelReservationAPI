using Entity.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) {}

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<AddressHotel> AddressHotels { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<HotelAmenity> HotelAmenities { get; set; }

        public DbSet<AmenityHotel> AmenityHotels { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomAmenity> RoomAmenities { get; set; }
        public DbSet<AmenityRoom>  AmenityRooms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties().Where(p => p.ClrType == typeof(string)))
                {
                    property.SetMaxLength(100);
                }
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyDbContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
