using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class addedcontainermodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "About",
                table: "Companies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Contact",
                table: "Companies",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "HomeJumbos",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    TextAlign = table.Column<string>(nullable: true),
                    TextFont = table.Column<string>(nullable: true),
                    TextColor = table.Column<string>(nullable: true),
                    TextSize = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeJumbos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeJumbos_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HomeJumbos_CompanyId",
                table: "HomeJumbos",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeJumbos");

            migrationBuilder.DropColumn(
                name: "About",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Contact",
                table: "Companies");
        }
    }
}
