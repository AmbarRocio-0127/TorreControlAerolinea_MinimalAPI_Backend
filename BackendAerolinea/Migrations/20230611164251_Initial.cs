using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BackendAerolinea.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aeropuerto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreAeropuerto_ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LimiteAviones_ = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aeropuerto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Avion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreAvion_ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Horasalida_ = table.Column<TimeSpan>(type: "time", nullable: false),
                    Horallegada_ = table.Column<TimeSpan>(type: "time", nullable: false),
                    Aeropuertosalida_ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aeropuertollegada_ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StatusVuelo_ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasajerosLimite = table.Column<int>(type: "int", nullable: false),
                    LimitePeso_ = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pasajeros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombrePasajero_ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PesoEquipaje_ = table.Column<int>(type: "int", nullable: false),
                    AvionId_ = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pasajeros", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aeropuerto");

            migrationBuilder.DropTable(
                name: "Avion");

            migrationBuilder.DropTable(
                name: "pasajeros");
        }
    }
}
