using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Data.Migrations
{
    public partial class addedtypetocompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Companies",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Companies");
        }
    }
}
