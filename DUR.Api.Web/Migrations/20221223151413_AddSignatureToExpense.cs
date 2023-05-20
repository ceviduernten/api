using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DUR.Api.Web.Migrations
{
    public partial class AddSignatureToExpense : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Signature",
                table: "Expense",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Signature",
                table: "Expense");
        }
    }
}
