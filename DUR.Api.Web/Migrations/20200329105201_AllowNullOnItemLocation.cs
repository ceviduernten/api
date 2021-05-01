using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace DUR.Api.Web.Migrations
{
    public partial class AllowNullOnItemLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_StorageLocation_LocationIdStorageLocation",
                table: "Item");

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationIdStorageLocation",
                table: "Item",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_StorageLocation_LocationIdStorageLocation",
                table: "Item",
                column: "LocationIdStorageLocation",
                principalTable: "StorageLocation",
                principalColumn: "IdStorageLocation",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_StorageLocation_LocationIdStorageLocation",
                table: "Item");

            migrationBuilder.AlterColumn<Guid>(
                name: "LocationIdStorageLocation",
                table: "Item",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_StorageLocation_LocationIdStorageLocation",
                table: "Item",
                column: "LocationIdStorageLocation",
                principalTable: "StorageLocation",
                principalColumn: "IdStorageLocation",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
