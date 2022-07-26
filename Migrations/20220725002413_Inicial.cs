using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace jQueryAjaxCRUDinASP.NETCoreMVC.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transacciones",
                columns: table => new
                {
                    TransaccionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroCuenta = table.Column<string>(type: "nvarchar(12)", nullable: false),
                    NombreBeneficiario = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    NombreBanco = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    CodigoSWIFT = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    Monto = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transacciones", x => x.TransaccionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transacciones");
        }
    }
}
