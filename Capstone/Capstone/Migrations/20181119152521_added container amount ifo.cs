using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class addedcontaineramountifo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContainerAmount",
                table: "AboutPages",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContainerAmount",
                table: "AboutPages");
        }
    }
}
