﻿// <auto-generated />
using System;
using Desafio_Teste_Ilia.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Desafio_Teste_Ilia.Migrations
{
    [DbContext(typeof(APIContext))]
    [Migration("20230216160328_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Desafio_Teste_Ilia.Models.Alocacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Dia")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProjetoId")
                        .HasColumnType("int");

                    b.Property<int?>("RelatorioId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Tempo")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoId");

                    b.HasIndex("RelatorioId");

                    b.ToTable("Alocacao");
                });

            modelBuilder.Entity("Desafio_Teste_Ilia.Models.Momento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RegistroId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RegistroId");

                    b.ToTable("Momento");
                });

            modelBuilder.Entity("Desafio_Teste_Ilia.Models.Projeto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("Desafio_Teste_Ilia.Models.Registro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Dia")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RelatorioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RelatorioId");

                    b.ToTable("Registros");
                });

            modelBuilder.Entity("Desafio_Teste_Ilia.Models.Relatorio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<TimeSpan>("HorasDevidas")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("HorasExcedentes")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("HorasTrabalhadas")
                        .HasColumnType("time");

                    b.Property<string>("Mes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Relatorios");
                });

            modelBuilder.Entity("Desafio_Teste_Ilia.Models.Alocacao", b =>
                {
                    b.HasOne("Desafio_Teste_Ilia.Models.Projeto", "Projeto")
                        .WithMany()
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Desafio_Teste_Ilia.Models.Relatorio", null)
                        .WithMany("Alocacoes")
                        .HasForeignKey("RelatorioId");

                    b.Navigation("Projeto");
                });

            modelBuilder.Entity("Desafio_Teste_Ilia.Models.Momento", b =>
                {
                    b.HasOne("Desafio_Teste_Ilia.Models.Registro", null)
                        .WithMany("Horarios")
                        .HasForeignKey("RegistroId");
                });

            modelBuilder.Entity("Desafio_Teste_Ilia.Models.Registro", b =>
                {
                    b.HasOne("Desafio_Teste_Ilia.Models.Relatorio", null)
                        .WithMany("Registros")
                        .HasForeignKey("RelatorioId");
                });

            modelBuilder.Entity("Desafio_Teste_Ilia.Models.Registro", b =>
                {
                    b.Navigation("Horarios");
                });

            modelBuilder.Entity("Desafio_Teste_Ilia.Models.Relatorio", b =>
                {
                    b.Navigation("Alocacoes");

                    b.Navigation("Registros");
                });
#pragma warning restore 612, 618
        }
    }
}
