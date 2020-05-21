using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace Datos.Migrations
{
    public partial class addTablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cultivos",
                columns: table => new
                {
                    CultivoId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cultivos", x => x.CultivoId);
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    MunicipioId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.MunicipioId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    NumeroCedula = table.Column<string>(nullable: false),
                    TipoUsuario = table.Column<int>(nullable: false),
                    TipoUsuarioNombre = table.Column<string>(nullable: true),
                    PrimerNombre = table.Column<string>(nullable: true),
                    SegundoNombre = table.Column<string>(nullable: true),
                    PrimerApellido = table.Column<string>(nullable: true),
                    SegundoApellido = table.Column<string>(nullable: true),
                    NombreCompleto = table.Column<string>(nullable: true),
                    UsuarioI = table.Column<string>(nullable: true),
                    Contrasena = table.Column<string>(nullable: true),
                    Telefono = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.NumeroCedula);
                });

            migrationBuilder.CreateTable(
                name: "Productores",
                columns: table => new
                {
                    ProductorId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    MunicipioId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
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
                    table.PrimaryKey("PK_Productores", x => x.ProductorId);
                    table.ForeignKey(
                        name: "FK_Productores_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "MunicipioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Agroclimaticas",
                columns: table => new
                {
                    AgroclimaticaId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProductorId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_Agroclimaticas", x => x.AgroclimaticaId);
                    table.ForeignKey(
                        name: "FK_Agroclimaticas_Productores_ProductorId",
                        column: x => x.ProductorId,
                        principalTable: "Productores",
                        principalColumn: "ProductorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DatosFamilias",
                columns: table => new
                {
                    Identificacion = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProductorId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    FechaNacimiento = table.Column<string>(nullable: true),
                    Parentesco = table.Column<string>(nullable: true),
                    TipoPoblacion = table.Column<string>(nullable: true),
                    AfilicionSalud = table.Column<string>(nullable: true),
                    NivelEducativo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatosFamilias", x => x.Identificacion);
                    table.ForeignKey(
                        name: "FK_DatosFamilias_Productores_ProductorId",
                        column: x => x.ProductorId,
                        principalTable: "Productores",
                        principalColumn: "ProductorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsumoExternos",
                columns: table => new
                {
                    InsumoExternoId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProductorId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Fabricante = table.Column<string>(nullable: true),
                    RegistroICA = table.Column<string>(nullable: true),
                    Composicion = table.Column<string>(nullable: true),
                    Dosis = table.Column<string>(nullable: true),
                    Cantidad = table.Column<string>(nullable: true),
                    FechaAplicacion = table.Column<string>(nullable: true),
                    LugarAplicacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsumoExternos", x => x.InsumoExternoId);
                    table.ForeignKey(
                        name: "FK_InsumoExternos_Productores_ProductorId",
                        column: x => x.ProductorId,
                        principalTable: "Productores",
                        principalColumn: "ProductorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsumoInternos",
                columns: table => new
                {
                    InsumoInternoId = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    ProductorId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_InsumoInternos", x => x.InsumoInternoId);
                    table.ForeignKey(
                        name: "FK_InsumoInternos_Productores_ProductorId",
                        column: x => x.ProductorId,
                        principalTable: "Productores",
                        principalColumn: "ProductorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agroclimaticas_ProductorId",
                table: "Agroclimaticas",
                column: "ProductorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DatosFamilias_ProductorId",
                table: "DatosFamilias",
                column: "ProductorId");

            migrationBuilder.CreateIndex(
                name: "IX_InsumoExternos_ProductorId",
                table: "InsumoExternos",
                column: "ProductorId");

            migrationBuilder.CreateIndex(
                name: "IX_InsumoInternos_ProductorId",
                table: "InsumoInternos",
                column: "ProductorId");

            migrationBuilder.CreateIndex(
                name: "IX_Productores_MunicipioId",
                table: "Productores",
                column: "MunicipioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agroclimaticas");

            migrationBuilder.DropTable(
                name: "Cultivos");

            migrationBuilder.DropTable(
                name: "DatosFamilias");

            migrationBuilder.DropTable(
                name: "InsumoExternos");

            migrationBuilder.DropTable(
                name: "InsumoInternos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Productores");

            migrationBuilder.DropTable(
                name: "Municipios");
        }
    }
}
