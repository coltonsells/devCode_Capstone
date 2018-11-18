using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class addedhomecontainertable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HomeContainers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    HomeId = table.Column<string>(nullable: true),
                    DivSection = table.Column<int>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Align = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Font = table.Column<string>(nullable: true),
                    FontSize = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomeContainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HomeContainers_HomePages_HomeId",
                        column: x => x.HomeId,
                        principalTable: "HomePages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HomeContainers_HomeId",
                table: "HomeContainers",
                column: "HomeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HomeContainers");
        }
    }
}
