using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class RemovedBusCapacityBookingsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Buses_BusCapacity",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_BusCapacity",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "BusCapacity",
                table: "Bookings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BusCapacity",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BusCapacity",
                table: "Bookings",
                column: "BusCapacity");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Buses_BusCapacity",
                table: "Bookings",
                column: "BusCapacity",
                principalTable: "Buses",
                principalColumn: "BusId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
