using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class BusTimeTablesCompanyProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "BusTimeTables",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BusTimeTables_CompanyId",
                table: "BusTimeTables",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusTimeTables_BusCompanies_CompanyId",
                table: "BusTimeTables",
                column: "CompanyId",
                principalTable: "BusCompanies",
                principalColumn: "CompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusTimeTables_BusCompanies_CompanyId",
                table: "BusTimeTables");

            migrationBuilder.DropIndex(
                name: "IX_BusTimeTables_CompanyId",
                table: "BusTimeTables");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "BusTimeTables");
        }
    }
}
