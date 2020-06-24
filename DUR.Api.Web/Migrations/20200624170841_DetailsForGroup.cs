using Microsoft.EntityFrameworkCore.Migrations;

namespace DUR.Api.Web.Migrations
{
    public partial class DetailsForGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MailLeaders",
                table: "Group",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NumberNotification",
                table: "Group",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MailLeaders",
                table: "Group");

            migrationBuilder.DropColumn(
                name: "NumberNotification",
                table: "Group");
        }
    }
}
