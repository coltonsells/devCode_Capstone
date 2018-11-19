using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class addedbackgroundcoloroption : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BgColor",
                table: "HomeContainers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NavTag",
                table: "ContactPages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NavTag",
                table: "AboutPages",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BgColor",
                table: "HomeContainers");

            migrationBuilder.DropColumn(
                name: "NavTag",
                table: "ContactPages");

            migrationBuilder.DropColumn(
                name: "NavTag",
                table: "AboutPages");
        }
    }
}
