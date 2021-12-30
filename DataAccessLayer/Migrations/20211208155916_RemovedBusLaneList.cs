using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class RemovedBusLaneList : Migration
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
