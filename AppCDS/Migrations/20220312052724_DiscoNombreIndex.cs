using Microsoft.EntityFrameworkCore.Migrations;

namespace AppCDS.Migrations
{
    public partial class DiscoNombreIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Disco_NombreDisco",
                table: "Disco",
                column: "NombreDisco",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Disco_NombreDisco",
                table: "Disco");
        }
    }
}
