using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class BusStationsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Gradovi",
                table: "Cities",
                newName: "CityName");

            migrationBuilder.RenameColumn(
                name: "GradId",
                table: "Cities",
                newName: "CityId");

            migrationBuilder.CreateTable(
                name: "BusStations",
                columns: table => new
                {
                    StationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusLines = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusStations", x => x.StationId);
                    table.ForeignKey(
                        name: "FK_BusStations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BusStations_CityId",
                table: "BusStations",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusStations");

            migrationBuilder.RenameColumn(
                name: "CityName",
                table: "Cities",
                newName: "Gradovi");

            migrationBuilder.RenameColumn(
                name: "CityId",
                table: "Cities",
                newName: "GradId");
        }
    }
}
