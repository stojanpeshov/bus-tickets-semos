using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class AddedBusIdToBookingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BusId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BusId",
                table: "Bookings",
                column: "BusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Buses_BusId",
                table: "Bookings",
                column: "BusId",
                principalTable: "Buses",
                principalColumn: "BusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Buses_BusId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_BusId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "BusId",
                table: "Bookings");
        }
    }
}
