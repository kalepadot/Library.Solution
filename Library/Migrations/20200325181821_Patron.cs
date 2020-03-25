using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class Patron : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Patrons",
                columns: table => new
                {
                    PatronId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patrons", x => x.PatronId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CopyPatron_PatronId",
                table: "CopyPatron",
                column: "PatronId");

            migrationBuilder.AddForeignKey(
                name: "FK_CopyPatron_Patrons_PatronId",
                table: "CopyPatron",
                column: "PatronId",
                principalTable: "Patrons",
                principalColumn: "PatronId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CopyPatron_Patrons_PatronId",
                table: "CopyPatron");

            migrationBuilder.DropTable(
                name: "Patrons");

            migrationBuilder.DropIndex(
                name: "IX_CopyPatron_PatronId",
                table: "CopyPatron");
        }
    }
}
