using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class removedparagraphchecksfromabouttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Paragraph1",
                table: "AboutPages");

            migrationBuilder.DropColumn(
                name: "Paragraph1Check",
                table: "AboutPages");

            migrationBuilder.DropColumn(
                name: "Paragraph2",
                table: "AboutPages");

            migrationBuilder.DropColumn(
                name: "Paragraph2Check",
                table: "AboutPages");

            migrationBuilder.DropColumn(
                name: "Paragraph3Check",
                table: "AboutPages");

            migrationBuilder.RenameColumn(
                name: "Paragraph3",
                table: "AboutPages",
                newName: "ContainerType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContainerType",
                table: "AboutPages",
                newName: "Paragraph3");

            migrationBuilder.AddColumn<string>(
                name: "Paragraph1",
                table: "AboutPages",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Paragraph1Check",
                table: "AboutPages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Paragraph2",
                table: "AboutPages",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Paragraph2Check",
                table: "AboutPages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Paragraph3Check",
                table: "AboutPages",
                nullable: false,
                defaultValue: false);
        }
    }
}
