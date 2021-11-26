using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class SecondUpdateOfBusLanesAndCities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusLanes_Cities_CityId",
                table: "BusLanes");

            migrationBuilder.DropIndex(
                name: "IX_BusLanes_CityId",
                table: "BusLanes");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "BusLanes");

            migrationBuilder.AddColumn<int>(
                name: "BusLanesId",
                table: "Cities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_BusLanesId",
                table: "Cities",
                column: "BusLanesId",
                unique: true,
                filter: "[BusLanesId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_BusLanes_BusLanesId",
                table: "Cities",
                column: "BusLanesId",
                principalTable: "BusLanes",
                principalColumn: "LaneId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_BusLanes_BusLanesId",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_BusLanesId",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "BusLanesId",
                table: "Cities");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "BusLanes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusLanes_CityId",
                table: "BusLanes",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusLanes_Cities_CityId",
                table: "BusLanes",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
