using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DUR.Api.Web.Migrations
{
    public partial class StuffEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StorageLocation",
                columns: table => new
                {
                    IdStorageLocation = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    ModDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    Deleted = table.Column<bool>(nullable: false, defaultValue: false),
                    ShortName = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Zip = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageLocation", x => x.IdStorageLocation);
                });

            migrationBuilder.CreateTable(
                name: "Box",
                columns: table => new
                {
                    IdBox = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    ModDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    Deleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Description = table.Column<string>(nullable: true),
                    InUse = table.Column<bool>(nullable: false),
                    WithCover = table.Column<bool>(nullable: false),
                    Stackable = table.Column<bool>(nullable: false),
                    BoxType = table.Column<string>(nullable: true),
                    Producer = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    LocationIdStorageLocation = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Box", x => x.IdBox);
                    table.ForeignKey(
                        name: "FK_Box_StorageLocation_LocationIdStorageLocation",
                        column: x => x.LocationIdStorageLocation,
                        principalTable: "StorageLocation",
                        principalColumn: "IdStorageLocation",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Item",
                columns: table => new
                {
                    IdItem = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    ModDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    Deleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Description = table.Column<string>(nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Vulgo = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    LocationIdStorageLocation = table.Column<Guid>(nullable: false),
                    BoxIdBox = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item", x => x.IdItem);
                    table.ForeignKey(
                        name: "FK_Item_Box_BoxIdBox",
                        column: x => x.BoxIdBox,
                        principalTable: "Box",
                        principalColumn: "IdBox",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Item_StorageLocation_LocationIdStorageLocation",
                        column: x => x.LocationIdStorageLocation,
                        principalTable: "StorageLocation",
                        principalColumn: "IdStorageLocation",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Box_LocationIdStorageLocation",
                table: "Box",
                column: "LocationIdStorageLocation");

            migrationBuilder.CreateIndex(
                name: "IX_Item_BoxIdBox",
                table: "Item",
                column: "BoxIdBox");

            migrationBuilder.CreateIndex(
                name: "IX_Item_LocationIdStorageLocation",
                table: "Item",
                column: "LocationIdStorageLocation");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Item");

            migrationBuilder.DropTable(
                name: "Box");

            migrationBuilder.DropTable(
                name: "StorageLocation");
        }
    }
}
