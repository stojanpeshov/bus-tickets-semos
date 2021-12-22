using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class InitialDbCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BusCompanies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusCompanies", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegistrationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Buses",
                columns: table => new
                {
                    BusId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusCapacity = table.Column<int>(type: "int", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buses", x => x.BusId);
                    table.ForeignKey(
                        name: "FK_Buses_BusCompanies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "BusCompanies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusStations",
                columns: table => new
                {
                    StationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusStations", x => x.StationId);
                    table.ForeignKey(
                        name: "FK_BusStations_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    SeatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatNumber = table.Column<int>(type: "int", nullable: false),
                    BusId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.SeatId);
                    table.ForeignKey(
                        name: "FK_Seats_Buses_BusId",
                        column: x => x.BusId,
                        principalTable: "Buses",
                        principalColumn: "BusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BusLanes",
                columns: table => new
                {
                    LaneId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BusId = table.Column<int>(type: "int", nullable: false),
                    BusStartPointStationId = table.Column<int>(type: "int", nullable: true),
                    BusDestinationStationId = table.Column<int>(type: "int", nullable: true),
                    CityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusLanes", x => x.LaneId);
                    table.ForeignKey(
                        name: "FK_BusLanes_Buses_BusId",
                        column: x => x.BusId,
                        principalTable: "Buses",
                        principalColumn: "BusId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusLanes_BusStations_BusDestinationStationId",
                        column: x => x.BusDestinationStationId,
                        principalTable: "BusStations",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusLanes_BusStations_BusStartPointStationId",
                        column: x => x.BusStartPointStationId,
                        principalTable: "BusStations",
                        principalColumn: "StationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BusLanes_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusTimeTables",
                columns: table => new
                {
                    TimeTableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BusDepartureTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BusArrivalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    BusLaneLaneId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusTimeTables", x => x.TimeTableId);
                    table.ForeignKey(
                        name: "FK_BusTimeTables_BusCompanies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "BusCompanies",
                        principalColumn: "CompanyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusTimeTables_BusLanes_BusLaneLaneId",
                        column: x => x.BusLaneLaneId,
                        principalTable: "BusLanes",
                        principalColumn: "LaneId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TimeTableId = table.Column<int>(type: "int", nullable: false),
                    SeatId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_BusTimeTables_TimeTableId",
                        column: x => x.TimeTableId,
                        principalTable: "BusTimeTables",
                        principalColumn: "TimeTableId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TimeTableId",
                table: "Bookings",
                column: "TimeTableId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Buses_CompanyId",
                table: "Buses",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_BusLanes_BusDestinationStationId",
                table: "BusLanes",
                column: "BusDestinationStationId");

            migrationBuilder.CreateIndex(
                name: "IX_BusLanes_BusId",
                table: "BusLanes",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_BusLanes_BusStartPointStationId",
                table: "BusLanes",
                column: "BusStartPointStationId");

            migrationBuilder.CreateIndex(
                name: "IX_BusLanes_CityId",
                table: "BusLanes",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_BusStations_CityId",
                table: "BusStations",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_BusTimeTables_BusLaneLaneId",
                table: "BusTimeTables",
                column: "BusLaneLaneId");

            migrationBuilder.CreateIndex(
                name: "IX_BusTimeTables_CompanyId",
                table: "BusTimeTables",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_BusId",
                table: "Seats",
                column: "BusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "BusTimeTables");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "BusLanes");

            migrationBuilder.DropTable(
                name: "Buses");

            migrationBuilder.DropTable(
                name: "BusStations");

            migrationBuilder.DropTable(
                name: "BusCompanies");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}
