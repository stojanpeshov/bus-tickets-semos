using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class UpdatedSeatsTableMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatName",
                table: "Seats");

            migrationBuilder.AddColumn<int>(
                name: "BusId",
                table: "Seats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seats_BusId",
                table: "Seats",
                column: "BusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Buses_BusId",
                table: "Seats",
                column: "BusId",
                principalTable: "Buses",
                principalColumn: "BusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Buses_BusId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_BusId",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "BusId",
                table: "Seats");

            migrationBuilder.AddColumn<string>(
                name: "SeatName",
                table: "Seats",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
