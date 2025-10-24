using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSia2025.BD.Migrations
{
    /// <inheritdoc />
    public partial class EBaseEnumEstadoRegistro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "Empresas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "Empresas");
        }
    }
}
