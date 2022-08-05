﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using plataformasGrupo5TPFinal.Data;

namespace plataformasGrupo5TPFinal.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20220725231340_database v2")]
    partial class databasev2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("plataformasGrupo5TPFinal.Models.Alojamiento", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("aBarrio")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("aCantPersonas")
                        .HasColumnType("int");

                    b.Property<string>("aCiudad")
                        .IsRequired()
                        .HasColumnType("varchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("aCodigo")
                        .HasColumnType("int");

                    b.Property<int>("aEstrellas")
                        .HasColumnType("int");

                    b.Property<bool>("aTV")
                        .HasColumnType("bit");

                    b.Property<int>("cHabitaciones")
                        .HasColumnType("int");

                    b.Property<double>("cPrecioxDia")
                        .HasColumnType("float");

                    b.Property<int>("cbanios")
                        .HasColumnType("int");

                    b.Property<double>("hPrecioxPersona")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.ToTable("Alojamiento");
                });

            modelBuilder.Entity("plataformasGrupo5TPFinal.Models.Reservas", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("codAlojamiento")
                        .HasColumnType("int");

                    b.Property<int>("dniPersona")
                        .HasColumnType("int");

                    b.Property<DateTime>("fDesde")
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("fHasta")
                        .HasColumnType("DateTime");

                    b.Property<float>("precio")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.ToTable("reservas");
                });

            modelBuilder.Entity("plataformasGrupo5TPFinal.Models.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("bloqueado")
                        .HasColumnType("bit");

                    b.Property<int>("dni")
                        .HasColumnType("int");

                    b.Property<bool>("esAdmin")
                        .HasColumnType("bit");

                    b.Property<int>("intentos")
                        .HasColumnType("int");

                    b.Property<string>("mail")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("nombre")
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("password")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("id");

                    b.ToTable("Usuarios");
                });
#pragma warning restore 612, 618
        }
    }
}