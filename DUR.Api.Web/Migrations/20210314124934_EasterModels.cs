using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DUR.Api.Web.Migrations
{
    public partial class EasterModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HuntCity",
                columns: table => new
                {
                    IdHuntCity = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Zip = table.Column<string>(type: "text", nullable: true),
                    StartLocationLat = table.Column<string>(type: "text", nullable: true),
                    StartLocationLong = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HuntCity", x => x.IdHuntCity);
                });

            migrationBuilder.CreateTable(
                name: "HuntLocation",
                columns: table => new
                {
                    IdHuntLocation = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsFound = table.Column<bool>(type: "boolean", nullable: false),
                    HuntCityIdHuntCity = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    ModDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "NOW()"),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HuntLocation", x => x.IdHuntLocation);
                    table.ForeignKey(
                        name: "FK_HuntLocation_HuntCity_HuntCityIdHuntCity",
                        column: x => x.HuntCityIdHuntCity,
                        principalTable: "HuntCity",
                        principalColumn: "IdHuntCity",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HuntLocation_HuntCityIdHuntCity",
                table: "HuntLocation",
                column: "HuntCityIdHuntCity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HuntLocation");

            migrationBuilder.DropTable(
                name: "HuntCity");
        }
    }
}
