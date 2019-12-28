using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DUR.Api.Web.Migrations
{
    public partial class AppointmentsAndRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Mail",
                table: "Group",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Appointment",
                columns: table => new
                {
                    IdAppointment = table.Column<Guid>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    ModDate = table.Column<DateTime>(nullable: false, defaultValueSql: "NOW()"),
                    Deleted = table.Column<bool>(nullable: false, defaultValue: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Time = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Infos = table.Column<string>(nullable: true),
                    GroupId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointment", x => x.IdAppointment);
                    table.ForeignKey(
                        name: "FK_Appointment_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "IdGroup",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointment_GroupId",
                table: "Appointment",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Appointment");

            migrationBuilder.DropColumn(
                name: "Mail",
                table: "Group");
        }
    }
}
