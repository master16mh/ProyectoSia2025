using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSia2025.BD.Migrations
{
    /// <inheritdoc />
    public partial class getEmpresaContacto2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactoEmpresas_Empresas_EmpresaId",
                table: "ContactoEmpresas");

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "ContactoEmpresas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactoEmpresas_Empresas_EmpresaId",
                table: "ContactoEmpresas",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactoEmpresas_Empresas_EmpresaId",
                table: "ContactoEmpresas");

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "ContactoEmpresas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactoEmpresas_Empresas_EmpresaId",
                table: "ContactoEmpresas",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id");
        }
    }
}
