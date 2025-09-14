using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSia2025.BD.Migrations
{
    /// <inheritdoc />
    public partial class ContactosDto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactoEmpresas_Empresas_EmpresaId",
                table: "ContactoEmpresas");

            migrationBuilder.AlterColumn<string>(
                name: "CUIT",
                table: "Empresas",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "EmpresaId",
                table: "ContactoEmpresas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "DNI",
                table: "ContactoEmpresas",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Estado",
                table: "ContactoEmpresas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Observacion",
                table: "ContactoEmpresas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "Empresa_CUIT",
                table: "Empresas",
                column: "CUIT",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Contacto_DNI",
                table: "ContactoEmpresas",
                column: "DNI",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactoEmpresas_Empresas_EmpresaId",
                table: "ContactoEmpresas",
                column: "EmpresaId",
                principalTable: "Empresas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactoEmpresas_Empresas_EmpresaId",
                table: "ContactoEmpresas");

            migrationBuilder.DropIndex(
                name: "Empresa_CUIT",
                table: "Empresas");

            migrationBuilder.DropIndex(
                name: "Contacto_DNI",
                table: "ContactoEmpresas");

            migrationBuilder.DropColumn(
                name: "DNI",
                table: "ContactoEmpresas");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "ContactoEmpresas");

            migrationBuilder.DropColumn(
                name: "Observacion",
                table: "ContactoEmpresas");

            migrationBuilder.AlterColumn<string>(
                name: "CUIT",
                table: "Empresas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
    }
}
