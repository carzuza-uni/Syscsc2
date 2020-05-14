using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class AddTablaProveedores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Proveedores",
                columns: table => new
                {
                    ProveedorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MunicipioId = table.Column<int>(nullable: false),
                    Cedula = table.Column<string>(nullable: true),
                    CedulaCafetera = table.Column<string>(nullable: true),
                    NombrePredio = table.Column<string>(nullable: true),
                    CodigoFinca = table.Column<string>(nullable: true),
                    CodigoSICA = table.Column<string>(nullable: true),
                    Actividades = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    AfiliacionSalud = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.ProveedorId);
                    table.ForeignKey(
                        name: "FK_Proveedores_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "CultivoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agroclimatica",
                columns: table => new
                {
                    AgroclimaticaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProveedorId = table.Column<int>(nullable: false),
                    Latitud = table.Column<string>(nullable: true),
                    NorteLongitud = table.Column<string>(nullable: true),
                    Este = table.Column<string>(nullable: true),
                    MSNM = table.Column<string>(nullable: true),
                    AnalisisSuelo = table.Column<string>(nullable: true),
                    FechaRealizacion = table.Column<string>(nullable: true),
                    PlanFertilizacion = table.Column<string>(nullable: true),
                    TipoTextura = table.Column<string>(nullable: true),
                    PreparacionAbono = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Observaciones = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agroclimatica", x => x.AgroclimaticaId);
                    table.ForeignKey(
                        name: "FK_Agroclimatica_Proveedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "ProveedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DatosFamilia",
                columns: table => new
                {
                    Identificacion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProveedorId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<string>(nullable: true),
                    Parentesco = table.Column<string>(nullable: true),
                    TipoPoblacion = table.Column<string>(nullable: true),
                    AfilicionSalud = table.Column<string>(nullable: true),
                    NivelEducativo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatosFamilia", x => x.Identificacion);
                    table.ForeignKey(
                        name: "FK_DatosFamilia_Proveedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "ProveedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsumoExterno",
                columns: table => new
                {
                    AgroclimaticaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProveedorId = table.Column<int>(nullable: false),
                    Latitud = table.Column<string>(nullable: true),
                    NorteLongitud = table.Column<string>(nullable: true),
                    Este = table.Column<string>(nullable: true),
                    MSNM = table.Column<string>(nullable: true),
                    AnalisisSuelo = table.Column<string>(nullable: true),
                    FechaRealizacion = table.Column<string>(nullable: true),
                    PlanFertilizacion = table.Column<string>(nullable: true),
                    TipoTextura = table.Column<string>(nullable: true),
                    PreparacionAbono = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true),
                    Estado = table.Column<string>(nullable: true),
                    Observaciones = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsumoExterno", x => x.AgroclimaticaId);
                    table.ForeignKey(
                        name: "FK_InsumoExterno_Proveedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "ProveedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsumoInterno",
                columns: table => new
                {
                    InsumoInternoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProveedorId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    MaterialesUsado = table.Column<string>(nullable: true),
                    Procedimiento = table.Column<string>(nullable: true),
                    TiempoPreparacion = table.Column<string>(nullable: true),
                    MetodoPreparacion = table.Column<string>(nullable: true),
                    Dosis = table.Column<string>(nullable: true),
                    Cantidad = table.Column<string>(nullable: true),
                    FechaAplicacion = table.Column<string>(nullable: true),
                    LugarAplicacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsumoInterno", x => x.InsumoInternoId);
                    table.ForeignKey(
                        name: "FK_InsumoInterno_Proveedores_ProveedorId",
                        column: x => x.ProveedorId,
                        principalTable: "Proveedores",
                        principalColumn: "ProveedorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agroclimatica_ProveedorId",
                table: "Agroclimatica",
                column: "ProveedorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DatosFamilia_ProveedorId",
                table: "DatosFamilia",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_InsumoExterno_ProveedorId",
                table: "InsumoExterno",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_InsumoInterno_ProveedorId",
                table: "InsumoInterno",
                column: "ProveedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Proveedores_MunicipioId",
                table: "Proveedores",
                column: "MunicipioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agroclimatica");

            migrationBuilder.DropTable(
                name: "DatosFamilia");

            migrationBuilder.DropTable(
                name: "InsumoExterno");

            migrationBuilder.DropTable(
                name: "InsumoInterno");

            migrationBuilder.DropTable(
                name: "Proveedores");
        }
    }
}
