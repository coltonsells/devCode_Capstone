using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class addedaboutcontainers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutContainers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AboutId = table.Column<string>(nullable: true),
                    DivSection = table.Column<int>(nullable: false),
                    Image = table.Column<byte[]>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    Align = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Font = table.Column<string>(nullable: true),
                    FontSize = table.Column<string>(nullable: true),
                    BgColor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutContainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AboutContainers_AboutPages_AboutId",
                        column: x => x.AboutId,
                        principalTable: "AboutPages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AboutContainers_AboutId",
                table: "AboutContainers",
                column: "AboutId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutContainers");
        }
    }
}
