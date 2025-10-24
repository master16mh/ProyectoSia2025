using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoSia2025.BD.Migrations
{
    /// <inheritdoc />
    public partial class NuevaMigCorreccion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CUIT = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaUltimoAcceso = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Obras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpresaId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Obras_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistorialAcciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Accion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntidadModificada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EntidadId = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialAcciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistorialAcciones_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Diseños",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObraId = table.Column<int>(type: "int", nullable: false),
                    DiseñadorId = table.Column<int>(type: "int", nullable: false),
                    NombreArchivo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaSubida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UrlArchivo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diseños", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diseños_Obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diseños_usuarios_DiseñadorId",
                        column: x => x.DiseñadorId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inspecciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ObraId = table.Column<int>(type: "int", nullable: false),
                    InspectorId = table.Column<int>(type: "int", nullable: false),
                    FechaInspeccion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ObservacionesGenerales = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChecklistUtilizado = table.Column<bool>(type: "bit", nullable: false),
                    SeGeneraInforme = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspecciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inspecciones_Obras_ObraId",
                        column: x => x.ObraId,
                        principalTable: "Obras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inspecciones_usuarios_InspectorId",
                        column: x => x.InspectorId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Informes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspeccionId = table.Column<int>(type: "int", nullable: false),
                    Resumen = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TieneIrregularidades = table.Column<bool>(type: "bit", nullable: false),
                    GeneradoPorId = table.Column<int>(type: "int", nullable: false),
                    FechaGeneracion = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Informes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Informes_Inspecciones_InspeccionId",
                        column: x => x.InspeccionId,
                        principalTable: "Inspecciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Informes_usuarios_GeneradoPorId",
                        column: x => x.GeneradoPorId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InspeccionCheckLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspeccionId = table.Column<int>(type: "int", nullable: false),
                    ChecklistItemId = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InspeccionCheckLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InspeccionCheckLists_CheckLists_ChecklistItemId",
                        column: x => x.ChecklistItemId,
                        principalTable: "CheckLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InspeccionCheckLists_Inspecciones_InspeccionId",
                        column: x => x.InspeccionId,
                        principalTable: "Inspecciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seguimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InspeccionId = table.Column<int>(type: "int", nullable: false),
                    FechaSeguimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RealizadoPorId = table.Column<int>(type: "int", nullable: false),
                    Corregido = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seguimientos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seguimientos_Inspecciones_InspeccionId",
                        column: x => x.InspeccionId,
                        principalTable: "Inspecciones",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seguimientos_usuarios_RealizadoPorId",
                        column: x => x.RealizadoPorId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diseños_DiseñadorId",
                table: "Diseños",
                column: "DiseñadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Diseños_ObraId",
                table: "Diseños",
                column: "ObraId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialAcciones_UsuarioId",
                table: "HistorialAcciones",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Informes_GeneradoPorId",
                table: "Informes",
                column: "GeneradoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Informes_InspeccionId",
                table: "Informes",
                column: "InspeccionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InspeccionCheckLists_ChecklistItemId",
                table: "InspeccionCheckLists",
                column: "ChecklistItemId");

            migrationBuilder.CreateIndex(
                name: "IX_InspeccionCheckLists_InspeccionId",
                table: "InspeccionCheckLists",
                column: "InspeccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspecciones_InspectorId",
                table: "Inspecciones",
                column: "InspectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Inspecciones_ObraId",
                table: "Inspecciones",
                column: "ObraId");

            migrationBuilder.CreateIndex(
                name: "IX_Obras_EmpresaId",
                table: "Obras",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Seguimientos_InspeccionId",
                table: "Seguimientos",
                column: "InspeccionId");

            migrationBuilder.CreateIndex(
                name: "IX_Seguimientos_RealizadoPorId",
                table: "Seguimientos",
                column: "RealizadoPorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diseños");

            migrationBuilder.DropTable(
                name: "HistorialAcciones");

            migrationBuilder.DropTable(
                name: "Informes");

            migrationBuilder.DropTable(
                name: "InspeccionCheckLists");

            migrationBuilder.DropTable(
                name: "Seguimientos");

            migrationBuilder.DropTable(
                name: "CheckLists");

            migrationBuilder.DropTable(
                name: "Inspecciones");

            migrationBuilder.DropTable(
                name: "Obras");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
