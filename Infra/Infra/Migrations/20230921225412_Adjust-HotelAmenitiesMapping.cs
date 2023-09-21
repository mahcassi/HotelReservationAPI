using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    public partial class AdjustHotelAmenitiesMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelAmenities_AmenityHotel_AmenityId",
                table: "HotelAmenities");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AmenityHotel",
                table: "AmenityHotel");

            migrationBuilder.RenameTable(
                name: "AmenityHotel",
                newName: "AmenityHotels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AmenityHotels",
                table: "AmenityHotels",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AmenityRooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AmenityRooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoomAmenities",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    AmenityId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAmenities", x => new { x.RoomId, x.AmenityId });
                    table.ForeignKey(
                        name: "FK_RoomAmenities_AmenityRooms_AmenityId",
                        column: x => x.AmenityId,
                        principalTable: "AmenityRooms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RoomAmenities_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenities_AmenityId",
                table: "RoomAmenities",
                column: "AmenityId");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelAmenities_AmenityHotels_AmenityId",
                table: "HotelAmenities",
                column: "AmenityId",
                principalTable: "AmenityHotels",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HotelAmenities_AmenityHotels_AmenityId",
                table: "HotelAmenities");

            migrationBuilder.DropTable(
                name: "RoomAmenities");

            migrationBuilder.DropTable(
                name: "AmenityRooms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AmenityHotels",
                table: "AmenityHotels");

            migrationBuilder.RenameTable(
                name: "AmenityHotels",
                newName: "AmenityHotel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AmenityHotel",
                table: "AmenityHotel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HotelAmenities_AmenityHotel_AmenityId",
                table: "HotelAmenities",
                column: "AmenityId",
                principalTable: "AmenityHotel",
                principalColumn: "Id");
        }
    }
}
