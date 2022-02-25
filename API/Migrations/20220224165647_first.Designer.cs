﻿// <auto-generated />
using System;
using API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Migrations
{
    [DbContext(typeof(BuildContext))]
    [Migration("20220224165647_first")]
    partial class first
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("API.Domain.Location.Address", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cep")
                        .HasColumnType("longtext");

                    b.Property<string>("Complemento")
                        .HasColumnType("longtext");

                    b.Property<string>("Numero")
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("API.Domain.RealState.Models.Condominium", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Academia")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("localizacaoID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("localizacaoID");

                    b.ToTable("Condominios");
                });

            modelBuilder.Entity("API.Domain.RealState.Models.RealStateObject", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("AceitaPets")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Garagem")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Mobiliado")
                        .HasColumnType("tinyint(1)");

                    b.Property<int?>("MoradorAtualID")
                        .HasColumnType("int");

                    b.Property<int>("NumeroBanheiros")
                        .HasColumnType("int");

                    b.Property<int>("NumeroSalas")
                        .HasColumnType("int");

                    b.Property<int>("Suites")
                        .HasColumnType("int");

                    b.Property<string>("Tamanho")
                        .HasColumnType("longtext");

                    b.Property<int>("Tipo")
                        .HasColumnType("int");

                    b.Property<int?>("localizacaoID")
                        .HasColumnType("int");

                    b.Property<double>("valor")
                        .HasColumnType("double");

                    b.HasKey("ID");

                    b.HasIndex("MoradorAtualID");

                    b.HasIndex("localizacaoID");

                    b.ToTable("Imoveis");
                });

            modelBuilder.Entity("API.Domain.User.UserObject", b =>
                {
                    b.Property<int?>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Phone")
                        .HasColumnType("longtext");

                    b.HasKey("ID");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("API.Domain.RealState.Models.Condominium", b =>
                {
                    b.HasOne("API.Domain.Location.Address", "localizacao")
                        .WithMany()
                        .HasForeignKey("localizacaoID");

                    b.Navigation("localizacao");
                });

            modelBuilder.Entity("API.Domain.RealState.Models.RealStateObject", b =>
                {
                    b.HasOne("API.Domain.User.UserObject", "MoradorAtual")
                        .WithMany()
                        .HasForeignKey("MoradorAtualID");

                    b.HasOne("API.Domain.Location.Address", "localizacao")
                        .WithMany()
                        .HasForeignKey("localizacaoID");

                    b.Navigation("localizacao");

                    b.Navigation("MoradorAtual");
                });
#pragma warning restore 612, 618
        }
    }
}
