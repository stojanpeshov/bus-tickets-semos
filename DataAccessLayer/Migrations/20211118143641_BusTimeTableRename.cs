using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class BusTimeTableRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_BusTimeTable_TimeTableId",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusTimeTable",
                table: "BusTimeTable");

            migrationBuilder.RenameTable(
                name: "BusTimeTable",
                newName: "BusTimeTables");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusTimeTables",
                table: "BusTimeTables",
                column: "TimeTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_BusTimeTables_TimeTableId",
                table: "Bookings",
                column: "TimeTableId",
                principalTable: "BusTimeTables",
                principalColumn: "TimeTableId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_BusTimeTables_TimeTableId",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BusTimeTables",
                table: "BusTimeTables");

            migrationBuilder.RenameTable(
                name: "BusTimeTables",
                newName: "BusTimeTable");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BusTimeTable",
                table: "BusTimeTable",
                column: "TimeTableId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_BusTimeTable_TimeTableId",
                table: "Bookings",
                column: "TimeTableId",
                principalTable: "BusTimeTable",
                principalColumn: "TimeTableId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
