using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class BookingsMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    TimeTableId = table.Column<int>(type: "int", nullable: true),
                    LaneId = table.Column<int>(type: "int", nullable: true),
                    BusCapacity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Buses_BusCapacity",
                        column: x => x.BusCapacity,
                        principalTable: "Buses",
                        principalColumn: "BusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_BusLanes_LaneId",
                        column: x => x.LaneId,
                        principalTable: "BusLanes",
                        principalColumn: "LaneId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_BusTimeTable_TimeTableId",
                        column: x => x.TimeTableId,
                        principalTable: "BusTimeTable",
                        principalColumn: "TimeTableId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BusCapacity",
                table: "Bookings",
                column: "BusCapacity");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_LaneId",
                table: "Bookings",
                column: "LaneId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TimeTableId",
                table: "Bookings",
                column: "TimeTableId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_UserId",
                table: "Bookings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");
        }
    }
}
