﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Desafio_Teste_Ilia.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Relatorios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HorasTrabalhadas = table.Column<TimeSpan>(type: "time", nullable: false),
                    HorasExcedentes = table.Column<TimeSpan>(type: "time", nullable: false),
                    HorasDevidas = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relatorios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Alocacao",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tempo = table.Column<TimeSpan>(type: "time", nullable: false),
                    ProjetoId = table.Column<int>(type: "int", nullable: false),
                    RelatorioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alocacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alocacao_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alocacao_Relatorios_RelatorioId",
                        column: x => x.RelatorioId,
                        principalTable: "Relatorios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Registros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RelatorioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Registros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Registros_Relatorios_RelatorioId",
                        column: x => x.RelatorioId,
                        principalTable: "Relatorios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Momento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegistroId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Momento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Momento_Registros_RegistroId",
                        column: x => x.RegistroId,
                        principalTable: "Registros",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alocacao_ProjetoId",
                table: "Alocacao",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_Alocacao_RelatorioId",
                table: "Alocacao",
                column: "RelatorioId");

            migrationBuilder.CreateIndex(
                name: "IX_Momento_RegistroId",
                table: "Momento",
                column: "RegistroId");

            migrationBuilder.CreateIndex(
                name: "IX_Registros_RelatorioId",
                table: "Registros",
                column: "RelatorioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alocacao");

            migrationBuilder.DropTable(
                name: "Momento");

            migrationBuilder.DropTable(
                name: "Projetos");

            migrationBuilder.DropTable(
                name: "Registros");

            migrationBuilder.DropTable(
                name: "Relatorios");
        }
    }
}
