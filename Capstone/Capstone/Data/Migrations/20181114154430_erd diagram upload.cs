using Microsoft.EntityFrameworkCore.Migrations;

namespace Capstone.Data.Migrations
{
    public partial class erddiagramupload : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatorId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Lat = table.Column<string>(nullable: true),
                    Long = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    Theme = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HomePages",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    Paragraph1 = table.Column<string>(nullable: true),
                    Paragraph2 = table.Column<string>(nullable: true),
                    Paragraph3 = table.Column<string>(nullable: true),
                    Maps = table.Column<bool>(nullable: false),
                    Twitter = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HomePages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AboutPages",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    Paragraph1 = table.Column<string>(nullable: true),
                    paragraph2 = table.Column<string>(nullable: true),
                    paragraph3 = table.Column<string>(nullable: true),
                    Maps = table.Column<bool>(nullable: false),
                    Twitter = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutPages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AboutPages_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactPages",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    Paragraph1 = table.Column<string>(nullable: true),
                    paragraph2 = table.Column<string>(nullable: true),
                    paragraph3 = table.Column<string>(nullable: true),
                    Maps = table.Column<bool>(nullable: false),
                    Twitter = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactPages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactPages_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    companyId = table.Column<string>(nullable: true),
                    ImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Images_Companies_companyId",
                        column: x => x.companyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpecialFeatures",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    Maps = table.Column<bool>(nullable: false),
                    Twitter = table.Column<bool>(nullable: false),
                    Schedule = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialFeatures_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StandardFeatures",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CompanyId = table.Column<string>(nullable: true),
                    Home = table.Column<bool>(nullable: false),
                    About = table.Column<bool>(nullable: false),
                    Contact = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StandardFeatures_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AboutPages_CompanyId",
                table: "AboutPages",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactPages_CompanyId",
                table: "ContactPages",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_companyId",
                table: "Images",
                column: "companyId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialFeatures_CompanyId",
                table: "SpecialFeatures",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardFeatures_CompanyId",
                table: "StandardFeatures",
                column: "CompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutPages");

            migrationBuilder.DropTable(
                name: "ContactPages");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "HomePages");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "SpecialFeatures");

            migrationBuilder.DropTable(
                name: "StandardFeatures");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
