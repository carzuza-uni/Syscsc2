using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Datos.Migrations
{
    public partial class TablasUsoSueloYManejocultivo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManejoCultivos",
                columns: table => new
                {
                    ManejoCultivoId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    AgroclimaticaId = table.Column<int>(nullable: false),
                    Lote = table.Column<string>(nullable: true),
                    Variedad = table.Column<string>(nullable: true),
                    NumeroArboles = table.Column<string>(nullable: true),
                    SistemaRenovacion = table.Column<string>(nullable: true),
                    FechaSiembra = table.Column<string>(nullable: true),
                    DistanciaSiembra = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManejoCultivos", x => x.ManejoCultivoId);
                    table.ForeignKey(
                        name: "FK_ManejoCultivos_Agroclimaticas_AgroclimaticaId",
                        column: x => x.AgroclimaticaId,
                        principalTable: "Agroclimaticas",
                        principalColumn: "AgroclimaticaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsoSuelos",
                columns: table => new
                {
                    UsoSueloId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    AgroclimaticaId = table.Column<int>(nullable: false),
                    Lote = table.Column<string>(nullable: true),
                    Area = table.Column<decimal>(nullable: false),
                    Usos = table.Column<string>(nullable: true),
                    Sombrio = table.Column<string>(nullable: true),
                    PlanteadoProximoAno = table.Column<string>(nullable: true),
                    Pendiente = table.Column<string>(nullable: true),
                    PresentaErosion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsoSuelos", x => x.UsoSueloId);
                    table.ForeignKey(
                        name: "FK_UsoSuelos_Agroclimaticas_AgroclimaticaId",
                        column: x => x.AgroclimaticaId,
                        principalTable: "Agroclimaticas",
                        principalColumn: "AgroclimaticaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManejoCultivos_AgroclimaticaId",
                table: "ManejoCultivos",
                column: "AgroclimaticaId");

            migrationBuilder.CreateIndex(
                name: "IX_UsoSuelos_AgroclimaticaId",
                table: "UsoSuelos",
                column: "AgroclimaticaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ManejoCultivos");

            migrationBuilder.DropTable(
                name: "UsoSuelos");
        }
    }
}
