using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace plataformasGrupo5TPFinal.Migrations
{
    public partial class databasev2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alojamiento",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aCodigo = table.Column<int>(type: "int", nullable: false),
                    aCiudad = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    aBarrio = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    aEstrellas = table.Column<int>(type: "int", nullable: false),
                    aCantPersonas = table.Column<int>(type: "int", nullable: false),
                    aTV = table.Column<bool>(type: "bit", nullable: false),
                    Tipo = table.Column<string>(type: "varchar(20)", nullable: false),
                    cPrecioxDia = table.Column<double>(type: "float", nullable: false),
                    cHabitaciones = table.Column<int>(type: "int", nullable: false),
                    cbanios = table.Column<int>(type: "int", nullable: false),
                    hPrecioxPersona = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alojamiento", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "reservas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fDesde = table.Column<DateTime>(type: "DateTime", nullable: false),
                    fHasta = table.Column<DateTime>(type: "DateTime", nullable: false),
                    codAlojamiento = table.Column<int>(type: "int", nullable: false),
                    dniPersona = table.Column<int>(type: "int", nullable: false),
                    precio = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reservas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dni = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    mail = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    esAdmin = table.Column<bool>(type: "bit", nullable: false),
                    bloqueado = table.Column<bool>(type: "bit", nullable: false),
                    intentos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alojamiento");

            migrationBuilder.DropTable(
                name: "reservas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
