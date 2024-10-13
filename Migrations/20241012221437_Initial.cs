using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarlosCustodio_Ap1_P1.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deudores",
                columns: table => new
                {
                    deudorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombres = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deudores", x => x.deudorId);
                });

            migrationBuilder.CreateTable(
                name: "Cobros",
                columns: table => new
                {
                    cobroId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fecha = table.Column<DateTime>(type: "TEXT", nullable: false),
                    monto = table.Column<decimal>(type: "TEXT", nullable: false),
                    deudorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobros", x => x.cobroId);
                    table.ForeignKey(
                        name: "FK_Cobros_Deudores_deudorId",
                        column: x => x.deudorId,
                        principalTable: "Deudores",
                        principalColumn: "deudorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prestamos",
                columns: table => new
                {
                    prestamoId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    deudorId = table.Column<int>(type: "INTEGER", nullable: false),
                    concepto = table.Column<string>(type: "TEXT", nullable: false),
                    monto = table.Column<decimal>(type: "TEXT", nullable: false),
                    balance = table.Column<decimal>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prestamos", x => x.prestamoId);
                    table.ForeignKey(
                        name: "FK_Prestamos_Deudores_deudorId",
                        column: x => x.deudorId,
                        principalTable: "Deudores",
                        principalColumn: "deudorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CobrosDetalles",
                columns: table => new
                {
                    detalleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    valorCobrado = table.Column<decimal>(type: "TEXT", nullable: false),
                    cobroId = table.Column<int>(type: "INTEGER", nullable: false),
                    prestamoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CobrosDetalles", x => x.detalleId);
                    table.ForeignKey(
                        name: "FK_CobrosDetalles_Cobros_cobroId",
                        column: x => x.cobroId,
                        principalTable: "Cobros",
                        principalColumn: "cobroId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CobrosDetalles_Prestamos_prestamoId",
                        column: x => x.prestamoId,
                        principalTable: "Prestamos",
                        principalColumn: "prestamoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Deudores",
                columns: new[] { "deudorId", "Nombres" },
                values: new object[,]
                {
                    { 1, "Carlos" },
                    { 2, "Maria" },
                    { 3, "Juancito" }
                });

            migrationBuilder.InsertData(
                table: "Cobros",
                columns: new[] { "cobroId", "deudorId", "fecha", "monto" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 2000m },
                    { 2, 2, new DateTime(2023, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3000m }
                });

            migrationBuilder.InsertData(
                table: "Prestamos",
                columns: new[] { "prestamoId", "balance", "concepto", "deudorId", "monto" },
                values: new object[,]
                {
                    { 1, 3000m, "Carro", 1, 5000m },
                    { 2, 5000m, "Carro", 2, 7000m }
                });

            migrationBuilder.InsertData(
                table: "CobrosDetalles",
                columns: new[] { "detalleId", "cobroId", "prestamoId", "valorCobrado" },
                values: new object[,]
                {
                    { 1, 1, 1, 1000m },
                    { 2, 2, 2, 4000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cobros_deudorId",
                table: "Cobros",
                column: "deudorId");

            migrationBuilder.CreateIndex(
                name: "IX_CobrosDetalles_cobroId",
                table: "CobrosDetalles",
                column: "cobroId");

            migrationBuilder.CreateIndex(
                name: "IX_CobrosDetalles_prestamoId",
                table: "CobrosDetalles",
                column: "prestamoId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_deudorId",
                table: "Prestamos",
                column: "deudorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CobrosDetalles");

            migrationBuilder.DropTable(
                name: "Cobros");

            migrationBuilder.DropTable(
                name: "Prestamos");

            migrationBuilder.DropTable(
                name: "Deudores");
        }
    }
}
