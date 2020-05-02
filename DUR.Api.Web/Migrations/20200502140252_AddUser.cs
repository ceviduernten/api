using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DUR.Api.Web.Migrations
{
    public partial class AddUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    IdUser = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    ModDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    Deleted = table.Column<bool>(nullable: false, defaultValue: false),
                    LoginName = table.Column<string>(nullable: true),
                    FullName = table.Column<string>(nullable: true),
                    Vulgo = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Role = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.IdUser);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
