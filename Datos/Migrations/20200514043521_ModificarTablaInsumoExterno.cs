using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class ModificarTablaInsumoExterno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_InsumoExternos",
                table: "InsumoExternos");

            migrationBuilder.DropColumn(
                name: "AgroclimaticaId",
                table: "InsumoExternos");

            migrationBuilder.DropColumn(
                name: "AnalisisSuelo",
                table: "InsumoExternos");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "InsumoExternos");

            migrationBuilder.DropColumn(
                name: "Este",
                table: "InsumoExternos");

            migrationBuilder.DropColumn(
                name: "FechaRealizacion",
                table: "InsumoExternos");

            migrationBuilder.DropColumn(
                name: "Latitud",
                table: "InsumoExternos");

            migrationBuilder.DropColumn(
                name: "MSNM",
                table: "InsumoExternos");

            migrationBuilder.DropColumn(
                name: "NorteLongitud",
                table: "InsumoExternos");

            migrationBuilder.DropColumn(
                name: "Observaciones",
                table: "InsumoExternos");

            migrationBuilder.DropColumn(
                name: "PlanFertilizacion",
                table: "InsumoExternos");

            migrationBuilder.DropColumn(
                name: "PreparacionAbono",
                table: "InsumoExternos");

            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "InsumoExternos");

            migrationBuilder.DropColumn(
                name: "TipoTextura",
                table: "InsumoExternos");

            migrationBuilder.AddColumn<int>(
                name: "InsumoExternoId",
                table: "InsumoExternos",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Cantidad",
                table: "InsumoExternos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Composicion",
                table: "InsumoExternos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Dosis",
                table: "InsumoExternos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Fabricante",
                table: "InsumoExternos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FechaAplicacion",
                table: "InsumoExternos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LugarAplicacion",
                table: "InsumoExternos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "InsumoExternos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RegistroICA",
                table: "InsumoExternos",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsumoExternos",
                table: "InsumoExternos",
                column: "InsumoExternoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_InsumoExternos",
                table: "InsumoExternos");

            migrationBuilder.DropColumn(
                name: "InsumoExternoId",
                table: "InsumoExternos");

            migrationBuilder.DropColumn(
                name: "Cantidad",
                table: "InsumoExternos");

            migrationBuilder.DropColumn(
                name: "Composicion",
                table: "InsumoExternos");

            migrationBuilder.DropColumn(
                name: "Dosis",
                table: "InsumoExternos");

            migrationBuilder.DropColumn(
                name: "Fabricante",
                table: "InsumoExternos");

            migrationBuilder.DropColumn(
                name: "FechaAplicacion",
                table: "InsumoExternos");

            migrationBuilder.DropColumn(
                name: "LugarAplicacion",
                table: "InsumoExternos");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "InsumoExternos");

            migrationBuilder.DropColumn(
                name: "RegistroICA",
                table: "InsumoExternos");

            migrationBuilder.AddColumn<int>(
                name: "AgroclimaticaId",
                table: "InsumoExternos",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "AnalisisSuelo",
                table: "InsumoExternos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "InsumoExternos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Este",
                table: "InsumoExternos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FechaRealizacion",
                table: "InsumoExternos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Latitud",
                table: "InsumoExternos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MSNM",
                table: "InsumoExternos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NorteLongitud",
                table: "InsumoExternos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Observaciones",
                table: "InsumoExternos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PlanFertilizacion",
                table: "InsumoExternos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PreparacionAbono",
                table: "InsumoExternos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "InsumoExternos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoTextura",
                table: "InsumoExternos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsumoExternos",
                table: "InsumoExternos",
                column: "AgroclimaticaId");
        }
    }
}
