using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteConhecimentoDb.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Atividades",
                columns: table => new
                {
                    CodAtv = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescAtv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vagas = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividades", x => x.CodAtv);
                });

            migrationBuilder.CreateTable(
                name: "Pacotes",
                columns: table => new
                {
                    CodPacote = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataViradaPreco = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacotes", x => x.CodPacote);
                });

            migrationBuilder.CreateTable(
                name: "Participantes",
                columns: table => new
                {
                    CodPar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participantes", x => x.CodPar);
                });

            migrationBuilder.CreateTable(
                name: "AxParticipanteAtividades",
                columns: table => new
                {
                    CodPar = table.Column<int>(type: "int", nullable: false),
                    CodAtv = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AxParticipanteAtividades", x => new { x.CodPar, x.CodAtv });
                    table.ForeignKey(
                        name: "FK_AxParticipanteAtividades_Atividades_CodAtv",
                        column: x => x.CodAtv,
                        principalTable: "Atividades",
                        principalColumn: "CodAtv",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AxParticipanteAtividades_Participantes_CodPar",
                        column: x => x.CodPar,
                        principalTable: "Participantes",
                        principalColumn: "CodPar",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AxParticipantePacotes",
                columns: table => new
                {
                    CodPar = table.Column<int>(type: "int", nullable: false),
                    CodPacote = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AxParticipantePacotes", x => new { x.CodPar, x.CodPacote });
                    table.ForeignKey(
                        name: "FK_AxParticipantePacotes_Pacotes_CodPacote",
                        column: x => x.CodPacote,
                        principalTable: "Pacotes",
                        principalColumn: "CodPacote",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AxParticipantePacotes_Participantes_CodPar",
                        column: x => x.CodPar,
                        principalTable: "Participantes",
                        principalColumn: "CodPar",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AxParticipanteAtividades_CodAtv",
                table: "AxParticipanteAtividades",
                column: "CodAtv");

            migrationBuilder.CreateIndex(
                name: "IX_AxParticipantePacotes_CodPacote",
                table: "AxParticipantePacotes",
                column: "CodPacote");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AxParticipanteAtividades");

            migrationBuilder.DropTable(
                name: "AxParticipantePacotes");

            migrationBuilder.DropTable(
                name: "Atividades");

            migrationBuilder.DropTable(
                name: "Pacotes");

            migrationBuilder.DropTable(
                name: "Participantes");
        }
    }
}
