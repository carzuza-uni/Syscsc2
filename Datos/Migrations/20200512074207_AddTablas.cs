using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class AddTablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agroclimatica_Proveedores_ProveedorId",
                table: "Agroclimatica");

            migrationBuilder.DropForeignKey(
                name: "FK_DatosFamilia_Proveedores_ProveedorId",
                table: "DatosFamilia");

            migrationBuilder.DropForeignKey(
                name: "FK_InsumoExterno_Proveedores_ProveedorId",
                table: "InsumoExterno");

            migrationBuilder.DropForeignKey(
                name: "FK_InsumoInterno_Proveedores_ProveedorId",
                table: "InsumoInterno");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsumoInterno",
                table: "InsumoInterno");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsumoExterno",
                table: "InsumoExterno");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DatosFamilia",
                table: "DatosFamilia");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agroclimatica",
                table: "Agroclimatica");

            migrationBuilder.RenameTable(
                name: "InsumoInterno",
                newName: "InsumoInternos");

            migrationBuilder.RenameTable(
                name: "InsumoExterno",
                newName: "InsumoExternos");

            migrationBuilder.RenameTable(
                name: "DatosFamilia",
                newName: "DatosFamilias");

            migrationBuilder.RenameTable(
                name: "Agroclimatica",
                newName: "Agroclimaticas");

            migrationBuilder.RenameIndex(
                name: "IX_InsumoInterno_ProveedorId",
                table: "InsumoInternos",
                newName: "IX_InsumoInternos_ProveedorId");

            migrationBuilder.RenameIndex(
                name: "IX_InsumoExterno_ProveedorId",
                table: "InsumoExternos",
                newName: "IX_InsumoExternos_ProveedorId");

            migrationBuilder.RenameIndex(
                name: "IX_DatosFamilia_ProveedorId",
                table: "DatosFamilias",
                newName: "IX_DatosFamilias_ProveedorId");

            migrationBuilder.RenameIndex(
                name: "IX_Agroclimatica_ProveedorId",
                table: "Agroclimaticas",
                newName: "IX_Agroclimaticas_ProveedorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsumoInternos",
                table: "InsumoInternos",
                column: "InsumoInternoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsumoExternos",
                table: "InsumoExternos",
                column: "AgroclimaticaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DatosFamilias",
                table: "DatosFamilias",
                column: "Identificacion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agroclimaticas",
                table: "Agroclimaticas",
                column: "AgroclimaticaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agroclimaticas_Proveedores_ProveedorId",
                table: "Agroclimaticas",
                column: "ProveedorId",
                principalTable: "Proveedores",
                principalColumn: "ProveedorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DatosFamilias_Proveedores_ProveedorId",
                table: "DatosFamilias",
                column: "ProveedorId",
                principalTable: "Proveedores",
                principalColumn: "ProveedorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InsumoExternos_Proveedores_ProveedorId",
                table: "InsumoExternos",
                column: "ProveedorId",
                principalTable: "Proveedores",
                principalColumn: "ProveedorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InsumoInternos_Proveedores_ProveedorId",
                table: "InsumoInternos",
                column: "ProveedorId",
                principalTable: "Proveedores",
                principalColumn: "ProveedorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agroclimaticas_Proveedores_ProveedorId",
                table: "Agroclimaticas");

            migrationBuilder.DropForeignKey(
                name: "FK_DatosFamilias_Proveedores_ProveedorId",
                table: "DatosFamilias");

            migrationBuilder.DropForeignKey(
                name: "FK_InsumoExternos_Proveedores_ProveedorId",
                table: "InsumoExternos");

            migrationBuilder.DropForeignKey(
                name: "FK_InsumoInternos_Proveedores_ProveedorId",
                table: "InsumoInternos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsumoInternos",
                table: "InsumoInternos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InsumoExternos",
                table: "InsumoExternos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DatosFamilias",
                table: "DatosFamilias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agroclimaticas",
                table: "Agroclimaticas");

            migrationBuilder.RenameTable(
                name: "InsumoInternos",
                newName: "InsumoInterno");

            migrationBuilder.RenameTable(
                name: "InsumoExternos",
                newName: "InsumoExterno");

            migrationBuilder.RenameTable(
                name: "DatosFamilias",
                newName: "DatosFamilia");

            migrationBuilder.RenameTable(
                name: "Agroclimaticas",
                newName: "Agroclimatica");

            migrationBuilder.RenameIndex(
                name: "IX_InsumoInternos_ProveedorId",
                table: "InsumoInterno",
                newName: "IX_InsumoInterno_ProveedorId");

            migrationBuilder.RenameIndex(
                name: "IX_InsumoExternos_ProveedorId",
                table: "InsumoExterno",
                newName: "IX_InsumoExterno_ProveedorId");

            migrationBuilder.RenameIndex(
                name: "IX_DatosFamilias_ProveedorId",
                table: "DatosFamilia",
                newName: "IX_DatosFamilia_ProveedorId");

            migrationBuilder.RenameIndex(
                name: "IX_Agroclimaticas_ProveedorId",
                table: "Agroclimatica",
                newName: "IX_Agroclimatica_ProveedorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsumoInterno",
                table: "InsumoInterno",
                column: "InsumoInternoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InsumoExterno",
                table: "InsumoExterno",
                column: "AgroclimaticaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DatosFamilia",
                table: "DatosFamilia",
                column: "Identificacion");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agroclimatica",
                table: "Agroclimatica",
                column: "AgroclimaticaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Agroclimatica_Proveedores_ProveedorId",
                table: "Agroclimatica",
                column: "ProveedorId",
                principalTable: "Proveedores",
                principalColumn: "ProveedorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DatosFamilia_Proveedores_ProveedorId",
                table: "DatosFamilia",
                column: "ProveedorId",
                principalTable: "Proveedores",
                principalColumn: "ProveedorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InsumoExterno_Proveedores_ProveedorId",
                table: "InsumoExterno",
                column: "ProveedorId",
                principalTable: "Proveedores",
                principalColumn: "ProveedorId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InsumoInterno_Proveedores_ProveedorId",
                table: "InsumoInterno",
                column: "ProveedorId",
                principalTable: "Proveedores",
                principalColumn: "ProveedorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
