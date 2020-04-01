using Microsoft.EntityFrameworkCore.Migrations;

namespace DUR.Api.Web.Migrations
{
    public partial class CorrectedTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vulgo",
                table: "Item");

            migrationBuilder.AddColumn<int>(
                name: "QuantityType",
                table: "Item",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuantityType",
                table: "Item");

            migrationBuilder.AddColumn<int>(
                name: "Vulgo",
                table: "Item",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
