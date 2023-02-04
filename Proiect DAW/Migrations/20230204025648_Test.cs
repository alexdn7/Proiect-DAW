using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Proiect_DAW.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Producatori",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producatori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vanzatori",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vanzatori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produse",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ImgURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Denumire = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descriere = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pret = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stoc = table.Column<int>(type: "int", nullable: false),
                    ProducatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produse_Producatori_ProducatorId",
                        column: x => x.ProducatorId,
                        principalTable: "Producatori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Produse_Vanzatori",
                columns: table => new
                {
                    ProdusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VanzatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produse_Vanzatori", x => new { x.ProdusId, x.VanzatorId });
                    table.ForeignKey(
                        name: "FK_Produse_Vanzatori_Produse_ProdusId",
                        column: x => x.ProdusId,
                        principalTable: "Produse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Produse_Vanzatori_Vanzatori_VanzatorId",
                        column: x => x.VanzatorId,
                        principalTable: "Vanzatori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produse_ProducatorId",
                table: "Produse",
                column: "ProducatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Produse_Vanzatori_VanzatorId",
                table: "Produse_Vanzatori",
                column: "VanzatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produse_Vanzatori");

            migrationBuilder.DropTable(
                name: "Produse");

            migrationBuilder.DropTable(
                name: "Vanzatori");

            migrationBuilder.DropTable(
                name: "Producatori");
        }
    }
}
