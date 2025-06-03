using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteConhecimentoDb.Migrations
{
    /// <inheritdoc />
    public partial class AtualizaPrecoPacoteVirada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "Pacotes",
                newName: "PrecoAposVirada");

            migrationBuilder.AddColumn<decimal>(
                name: "PrecoAntesVirada",
                table: "Pacotes",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Pacotes",
                keyColumn: "CodPacote",
                keyValue: 1,
                columns: new[] { "PrecoAntesVirada", "PrecoAposVirada" },
                values: new object[] { 100.00m, 150.00m });

            migrationBuilder.UpdateData(
                table: "Pacotes",
                keyColumn: "CodPacote",
                keyValue: 2,
                columns: new[] { "PrecoAntesVirada", "PrecoAposVirada" },
                values: new object[] { 150.00m, 200.00m });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrecoAntesVirada",
                table: "Pacotes");

            migrationBuilder.RenameColumn(
                name: "PrecoAposVirada",
                table: "Pacotes",
                newName: "Preco");

            migrationBuilder.UpdateData(
                table: "Pacotes",
                keyColumn: "CodPacote",
                keyValue: 1,
                column: "Preco",
                value: 100.00m);

            migrationBuilder.UpdateData(
                table: "Pacotes",
                keyColumn: "CodPacote",
                keyValue: 2,
                column: "Preco",
                value: 150.00m);
        }
    }
}
