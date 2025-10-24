using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSia2025.BD.Migrations
{
    /// <inheritdoc />
    public partial class CorrigiendoCampoModificadoEnTablaInspeccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EntidadModificada",
                table: "HistorialAcciones",
                newName: "CampoModificado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CampoModificado",
                table: "HistorialAcciones",
                newName: "EntidadModificada");
        }
    }
}
