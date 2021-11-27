using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class BusLanesFKRepair : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusLanes_Cities_CityId1",
                table: "BusLanes");

            migrationBuilder.DropIndex(
                name: "IX_BusLanes_CityId1",
                table: "BusLanes");

            migrationBuilder.DropColumn(
                name: "CityId1",
                table: "BusLanes");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusLanes_Cities_CityId",
                table: "BusLanes");

            migrationBuilder.DropIndex(
                name: "IX_BusLanes_CityId",
                table: "BusLanes");

            migrationBuilder.AddColumn<int>(
                name: "CityId1",
                table: "BusLanes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusLanes_CityId1",
                table: "BusLanes",
                column: "CityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BusLanes_Cities_CityId1",
                table: "BusLanes",
                column: "CityId1",
                principalTable: "Cities",
                principalColumn: "CityId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
