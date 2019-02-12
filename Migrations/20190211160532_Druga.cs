using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Automobili.Migrations
{
    public partial class Druga : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dostupnost",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MarkaId = table.Column<int>(nullable: false),
                    Tip = table.Column<string>(nullable: false),
                    GodinaProzvodnje = table.Column<string>(nullable: false),
                    BenzinDizel = table.Column<string>(nullable: false),
                    BrojBrzina = table.Column<int>(nullable: false),
                    Kontakt = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dostupnost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dostupnost_Marka_MarkaId",
                        column: x => x.MarkaId,
                        principalTable: "Marka",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dostupnost_MarkaId",
                table: "Dostupnost",
                column: "MarkaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dostupnost");
        }
    }
}
