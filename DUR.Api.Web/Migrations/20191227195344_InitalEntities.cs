using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DUR.Api.Web.Migrations
{
    public partial class InitalEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    IdGroup = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    ModDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    Deleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Leaders = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.IdGroup);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Group");
        }
    }
}
