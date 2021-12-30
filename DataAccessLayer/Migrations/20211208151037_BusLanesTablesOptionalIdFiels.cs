using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class BusLanesTablesOptionalIdFiels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusLanes_BusStations_BusDestinationStationId",
                table: "BusLanes");

            migrationBuilder.DropForeignKey(
                name: "FK_BusLanes_BusStations_BusStartPointStationId",
                table: "BusLanes");

            migrationBuilder.RenameColumn(
                name: "BusStartPointStationId",
                table: "BusLanes",
                newName: "BusStartPointId");

            migrationBuilder.RenameColumn(
                name: "BusDestinationStationId",
                table: "BusLanes",
                newName: "BusDestinationId");

            migrationBuilder.RenameIndex(
                name: "IX_BusLanes_BusStartPointStationId",
                table: "BusLanes",
                newName: "IX_BusLanes_BusStartPointId");

            migrationBuilder.RenameIndex(
                name: "IX_BusLanes_BusDestinationStationId",
                table: "BusLanes",
                newName: "IX_BusLanes_BusDestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusLanes_BusStations_BusDestinationId",
                table: "BusLanes",
                column: "BusDestinationId",
                principalTable: "BusStations",
                principalColumn: "StationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusLanes_BusStations_BusStartPointId",
                table: "BusLanes",
                column: "BusStartPointId",
                principalTable: "BusStations",
                principalColumn: "StationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusLanes_BusStations_BusDestinationId",
                table: "BusLanes");

            migrationBuilder.DropForeignKey(
                name: "FK_BusLanes_BusStations_BusStartPointId",
                table: "BusLanes");

            migrationBuilder.RenameColumn(
                name: "BusStartPointId",
                table: "BusLanes",
                newName: "BusStartPointStationId");

            migrationBuilder.RenameColumn(
                name: "BusDestinationId",
                table: "BusLanes",
                newName: "BusDestinationStationId");

            migrationBuilder.RenameIndex(
                name: "IX_BusLanes_BusStartPointId",
                table: "BusLanes",
                newName: "IX_BusLanes_BusStartPointStationId");

            migrationBuilder.RenameIndex(
                name: "IX_BusLanes_BusDestinationId",
                table: "BusLanes",
                newName: "IX_BusLanes_BusDestinationStationId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusLanes_BusStations_BusDestinationStationId",
                table: "BusLanes",
                column: "BusDestinationStationId",
                principalTable: "BusStations",
                principalColumn: "StationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusLanes_BusStations_BusStartPointStationId",
                table: "BusLanes",
                column: "BusStartPointStationId",
                principalTable: "BusStations",
                principalColumn: "StationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
