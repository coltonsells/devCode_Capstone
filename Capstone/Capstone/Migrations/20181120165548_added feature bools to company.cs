using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class addedfeatureboolstocompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ContactChoice",
                table: "Companies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MapChoice",
                table: "Companies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ScheduleChoice",
                table: "Companies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "TwitterChoice",
                table: "Companies",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactChoice",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "MapChoice",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ScheduleChoice",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "TwitterChoice",
                table: "Companies");
        }
    }
}
