using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio_Teste_Ilia.Migrations
{
    /// <inheritdoc />
    public partial class MigrationFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alocacao_Relatorios_RelatorioId",
                table: "Alocacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Registros_Relatorios_RelatorioId",
                table: "Registros");

            migrationBuilder.DropTable(
                name: "Relatorios");

            migrationBuilder.DropIndex(
                name: "IX_Registros_RelatorioId",
                table: "Registros");

            migrationBuilder.DropIndex(
                name: "IX_Alocacao_RelatorioId",
                table: "Alocacao");

            migrationBuilder.DropColumn(
                name: "RelatorioId",
                table: "Registros");

            migrationBuilder.DropColumn(
                name: "RelatorioId",
                table: "Alocacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RelatorioId",
                table: "Registros",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RelatorioId",
                table: "Alocacao",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Relatorios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HorasDevidas = table.Column<string>(type: "nvarchar(48)", nullable: false),
                    HorasExcedentes = table.Column<string>(type: "nvarchar(48)", nullable: false),
                    HorasTrabalhadas = table.Column<string>(type: "nvarchar(48)", nullable: false),
                    Mes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatorios", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Registros_RelatorioId",
                table: "Registros",
                column: "RelatorioId");

            migrationBuilder.CreateIndex(
                name: "IX_Alocacao_RelatorioId",
                table: "Alocacao",
                column: "RelatorioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alocacao_Relatorios_RelatorioId",
                table: "Alocacao",
                column: "RelatorioId",
                principalTable: "Relatorios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Registros_Relatorios_RelatorioId",
                table: "Registros",
                column: "RelatorioId",
                principalTable: "Relatorios",
                principalColumn: "Id");
        }
    }
}
