using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio_Teste_Ilia.Migrations
{
    /// <inheritdoc />
    public partial class MomentoMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Momento_Registros_RegistroId",
                table: "Momento");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Momento",
                table: "Momento");

            migrationBuilder.RenameTable(
                name: "Momento",
                newName: "Momentos");

            migrationBuilder.RenameIndex(
                name: "IX_Momento_RegistroId",
                table: "Momentos",
                newName: "IX_Momentos_RegistroId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Momentos",
                table: "Momentos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Momentos_Registros_RegistroId",
                table: "Momentos",
                column: "RegistroId",
                principalTable: "Registros",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Momentos_Registros_RegistroId",
                table: "Momentos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Momentos",
                table: "Momentos");

            migrationBuilder.RenameTable(
                name: "Momentos",
                newName: "Momento");

            migrationBuilder.RenameIndex(
                name: "IX_Momentos_RegistroId",
                table: "Momento",
                newName: "IX_Momento_RegistroId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Momento",
                table: "Momento",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Momento_Registros_RegistroId",
                table: "Momento",
                column: "RegistroId",
                principalTable: "Registros",
                principalColumn: "Id");
        }
    }
}
