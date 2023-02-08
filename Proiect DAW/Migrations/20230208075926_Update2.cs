using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_DAW.Migrations
{
    public partial class Update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LocatieId",
                table: "Producatori",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Locatii",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tara = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Oras = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Strada = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locatii", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producatori_LocatieId",
                table: "Producatori",
                column: "LocatieId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Producatori_Locatii_LocatieId",
                table: "Producatori",
                column: "LocatieId",
                principalTable: "Locatii",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Producatori_Locatii_LocatieId",
                table: "Producatori");

            migrationBuilder.DropTable(
                name: "Locatii");

            migrationBuilder.DropIndex(
                name: "IX_Producatori_LocatieId",
                table: "Producatori");

            migrationBuilder.DropColumn(
                name: "LocatieId",
                table: "Producatori");
        }
    }
}
