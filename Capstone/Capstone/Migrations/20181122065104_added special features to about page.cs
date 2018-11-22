using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class addedspecialfeaturestoaboutpage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Maps",
                table: "AboutContainers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Twitter",
                table: "AboutContainers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Maps",
                table: "AboutContainers");

            migrationBuilder.DropColumn(
                name: "Twitter",
                table: "AboutContainers");
        }
    }
}
