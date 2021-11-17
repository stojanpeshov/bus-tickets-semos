using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class BusCompaniesForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BusId",
                table: "BusCompanies",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BusCompanies_BusId",
                table: "BusCompanies",
                column: "BusId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusCompanies_Buses_BusId",
                table: "BusCompanies",
                column: "BusId",
                principalTable: "Buses",
                principalColumn: "BusId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusCompanies_Buses_BusId",
                table: "BusCompanies");

            migrationBuilder.DropIndex(
                name: "IX_BusCompanies_BusId",
                table: "BusCompanies");

            migrationBuilder.DropColumn(
                name: "BusId",
                table: "BusCompanies");
        }
    }
}
