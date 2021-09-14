using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Data.Migrations
{
    public partial class InitialMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Apellido = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EsConductor = table.Column<bool>(type: "bit", nullable: false),
                    UsaLentes = table.Column<bool>(type: "bit", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enfermedades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermedades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnfermedadCliente",
                columns: table => new
                {
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdEnfermedad = table.Column<int>(type: "int", nullable: false),
                    ClienteId = table.Column<int>(type: "int", nullable: true),
                    EnfermedadId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnfermedadCliente", x => new { x.IdCliente, x.IdEnfermedad });
                    table.ForeignKey(
                        name: "FK_EnfermedadCliente_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EnfermedadCliente_Enfermedades_EnfermedadId",
                        column: x => x.EnfermedadId,
                        principalTable: "Enfermedades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EnfermedadCliente_ClienteId",
                table: "EnfermedadCliente",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_EnfermedadCliente_EnfermedadId",
                table: "EnfermedadCliente",
                column: "EnfermedadId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnfermedadCliente");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Enfermedades");
        }
    }
}
