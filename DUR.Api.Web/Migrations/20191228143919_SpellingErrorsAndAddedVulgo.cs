using Microsoft.EntityFrameworkCore.Migrations;

namespace DUR.Api.Web.Migrations
{
    public partial class SpellingErrorsAndAddedVulgo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Stress",
                table: "Contact");

            migrationBuilder.AddColumn<string>(
                name: "Street",
                table: "Contact",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Vulgo",
                table: "Contact",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Street",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "Vulgo",
                table: "Contact");

            migrationBuilder.AddColumn<string>(
                name: "Stress",
                table: "Contact",
                type: "text",
                nullable: true);
        }
    }
}
