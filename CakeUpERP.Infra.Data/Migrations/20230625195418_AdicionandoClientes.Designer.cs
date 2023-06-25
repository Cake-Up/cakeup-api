﻿// <auto-generated />
using System;
using CakeUpERP.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CakeUpERP.Infra.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230625195418_AdicionandoClientes")]
    partial class AdicionandoClientes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CakeUpERP.Domain.Entities.ClienteEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("varchar(1)");

                    b.Property<int>("IdCompanhia")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("IdCompanhia");

                    b.ToTable("cliente", (string)null);
                });

            modelBuilder.Entity("CakeUpERP.Domain.Entities.CompanhiaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cnpj")
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NomeSite")
                        .HasMaxLength(80)
                        .HasColumnType("varchar(80)");

                    b.Property<string>("UrlImagem")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("companhia", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Cnpj = "64547425000106",
                            DataCriacao = new DateTime(2023, 6, 25, 16, 54, 17, 687, DateTimeKind.Local).AddTicks(4832),
                            Nome = "Companhia 01 Ltda",
                            UrlImagem = ""
                        });
                });

            modelBuilder.Entity("CakeUpERP.Domain.Entities.ObservacaoClienteEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataCriacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime(6)")
                        .HasDefaultValueSql("NOW()");

                    b.Property<DateTime?>("DataExclusao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataObservacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataUpdate")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<string>("Observacao")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.ToTable("observacao_cliente", (string)null);
                });

            modelBuilder.Entity("CakeUpERP.Domain.Entities.UsuarioEntity", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<bool>("Ativo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(true);

                    b.Property<int>("CompanhiaId")
                        .HasColumnType("int");

                    b.Property<string>("Cpf")
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime>("DataAtualizacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("DataExclusao")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DataExpiracaoRefreshToken")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<int>("IdCompanhia")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("longtext");

                    b.Property<int>("Role")
                        .HasMaxLength(32)
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasAlternateKey("Email");

                    b.HasIndex("CompanhiaId");

                    b.ToTable("usuario", (string)null);
                });

            modelBuilder.Entity("CakeUpERP.Domain.Entities.ClienteEntity", b =>
                {
                    b.HasOne("CakeUpERP.Domain.Entities.CompanhiaEntity", "Companhia")
                        .WithMany("Clientes")
                        .HasForeignKey("IdCompanhia")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Companhia");
                });

            modelBuilder.Entity("CakeUpERP.Domain.Entities.ObservacaoClienteEntity", b =>
                {
                    b.HasOne("CakeUpERP.Domain.Entities.ClienteEntity", "Cliente")
                        .WithMany("ObservacaoClienteEntities")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("CakeUpERP.Domain.Entities.UsuarioEntity", b =>
                {
                    b.HasOne("CakeUpERP.Domain.Entities.CompanhiaEntity", "Companhia")
                        .WithMany()
                        .HasForeignKey("CompanhiaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Companhia");
                });

            modelBuilder.Entity("CakeUpERP.Domain.Entities.ClienteEntity", b =>
                {
                    b.Navigation("ObservacaoClienteEntities");
                });

            modelBuilder.Entity("CakeUpERP.Domain.Entities.CompanhiaEntity", b =>
                {
                    b.Navigation("Clientes");
                });
#pragma warning restore 612, 618
        }
    }
}
