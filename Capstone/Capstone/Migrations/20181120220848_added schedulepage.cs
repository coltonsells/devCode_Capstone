using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class addedschedulepage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Scheduler",
                table: "Companies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "SchedulePages",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SchedulePages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SchedulePages_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    SchedulerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_SchedulePages_SchedulerId",
                        column: x => x.SchedulerId,
                        principalTable: "SchedulePages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_SchedulerId",
                table: "Events",
                column: "SchedulerId");

            migrationBuilder.CreateIndex(
                name: "IX_SchedulePages_CompanyId",
                table: "SchedulePages",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "SchedulePages");

            migrationBuilder.DropColumn(
                name: "Scheduler",
                table: "Companies");
        }
    }
}
