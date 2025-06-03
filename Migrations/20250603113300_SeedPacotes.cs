using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TesteConhecimentoDb.Migrations
{
    /// <inheritdoc />
    public partial class SeedPacotes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pacotes",
                columns: new[] { "CodPacote", "DataViradaPreco", "Descricao", "Preco" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gold", 100.00m },
                    { 2, new DateTime(2025, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Platinum", 150.00m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pacotes",
                keyColumn: "CodPacote",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pacotes",
                keyColumn: "CodPacote",
                keyValue: 2);
        }
    }
}
