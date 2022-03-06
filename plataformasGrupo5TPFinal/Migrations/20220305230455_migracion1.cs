using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace plataformasGrupo5TPFinal.Migrations
{
    public partial class migracion1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cabañas",
                columns: table => new
                {
                    idCabana = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ciudad = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    barrio = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    estrellas = table.Column<int>(type: "int", nullable: false),
                    cantPersonas = table.Column<int>(type: "int", nullable: false),
                    tv = table.Column<bool>(type: "bit", nullable: false),
                    precioDia = table.Column<float>(type: "real", nullable: false),
                    habitaciones = table.Column<int>(type: "int", nullable: false),
                    baños = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabañas", x => x.idCabana);
                });

            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    idHotel = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codigo = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ciudad = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    barrio = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    estrellas = table.Column<int>(type: "int", nullable: false),
                    cantPersonas = table.Column<int>(type: "int", nullable: false),
                    tv = table.Column<int>(type: "int", nullable: false),
                    precioPorPersona = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.idHotel);
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
                name: "Cabañas");

            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "reservas");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
