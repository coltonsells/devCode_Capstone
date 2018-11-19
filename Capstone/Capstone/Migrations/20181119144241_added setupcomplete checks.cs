using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class addedsetupcompletechecks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AboutSetupComplete",
                table: "Companies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ContactSetupComplete",
                table: "Companies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HomeSetupComplete",
                table: "Companies",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutSetupComplete",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "ContactSetupComplete",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "HomeSetupComplete",
                table: "Companies");
        }
    }
}
