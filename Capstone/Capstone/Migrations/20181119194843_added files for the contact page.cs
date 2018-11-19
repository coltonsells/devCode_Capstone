using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Migrations
{
    public partial class addedfilesforthecontactpage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Paragraph1",
                table: "ContactPages");

            migrationBuilder.DropColumn(
                name: "Paragraph1Check",
                table: "ContactPages");

            migrationBuilder.DropColumn(
                name: "Paragraph2",
                table: "ContactPages");

            migrationBuilder.DropColumn(
                name: "Paragraph2Check",
                table: "ContactPages");

            migrationBuilder.DropColumn(
                name: "Paragraph3Check",
                table: "ContactPages");

            migrationBuilder.RenameColumn(
                name: "Paragraph3",
                table: "ContactPages",
                newName: "ContainerType");

            migrationBuilder.AddColumn<int>(
                name: "ContainerAmount",
                table: "ContactPages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ContactContainers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ContactId = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_ContactContainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactContainers_ContactPages_ContactId",
                        column: x => x.ContactId,
                        principalTable: "ContactPages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactContainers_ContactId",
                table: "ContactContainers",
                column: "ContactId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactContainers");

            migrationBuilder.DropColumn(
                name: "ContainerAmount",
                table: "ContactPages");

            migrationBuilder.RenameColumn(
                name: "ContainerType",
                table: "ContactPages",
                newName: "Paragraph3");

            migrationBuilder.AddColumn<string>(
                name: "Paragraph1",
                table: "ContactPages",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Paragraph1Check",
                table: "ContactPages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Paragraph2",
                table: "ContactPages",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Paragraph2Check",
                table: "ContactPages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Paragraph3Check",
                table: "ContactPages",
                nullable: false,
                defaultValue: false);
        }
    }
}
