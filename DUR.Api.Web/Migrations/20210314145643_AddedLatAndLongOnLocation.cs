using Microsoft.EntityFrameworkCore.Migrations;

namespace DUR.Api.Web.Migrations
{
    public partial class AddedLatAndLongOnLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "HuntLocation",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "HuntLocation",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "HuntLocation");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "HuntLocation");
        }
    }
}
