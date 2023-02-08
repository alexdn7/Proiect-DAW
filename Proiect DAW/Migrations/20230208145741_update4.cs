using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_DAW.Migrations
{
    public partial class update4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adresa",
                table: "Producatori");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adresa",
                table: "Producatori",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
