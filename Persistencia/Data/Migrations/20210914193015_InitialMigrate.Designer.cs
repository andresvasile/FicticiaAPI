﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistencia.Data;

namespace Persistencia.Data.Migrations
{
    [DbContext(typeof(ContextoFicticia))]
    [Migration("20210914193015_InitialMigrate")]
    partial class InitialMigrate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dominio.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<bool>("EsConductor")
                        .HasColumnType("bit");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<bool>("UsaLentes")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Dominio.Enfermedad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Enfermedades");
                });

            modelBuilder.Entity("Dominio.EnfermedadCliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdEnfermedad")
                        .HasColumnType("int");

                    b.Property<int?>("ClienteId")
                        .HasColumnType("int");

                    b.Property<int?>("EnfermedadId")
                        .HasColumnType("int");

                    b.HasKey("IdCliente", "IdEnfermedad");

                    b.HasIndex("ClienteId");

                    b.HasIndex("EnfermedadId");

                    b.ToTable("EnfermedadCliente");
                });

            modelBuilder.Entity("Dominio.EnfermedadCliente", b =>
                {
                    b.HasOne("Dominio.Cliente", "Cliente")
                        .WithMany("EnfermedadClientes")
                        .HasForeignKey("ClienteId");

                    b.HasOne("Dominio.Enfermedad", "Enfermedad")
                        .WithMany("EnfermedadClientes")
                        .HasForeignKey("EnfermedadId");

                    b.Navigation("Cliente");

                    b.Navigation("Enfermedad");
                });

            modelBuilder.Entity("Dominio.Cliente", b =>
                {
                    b.Navigation("EnfermedadClientes");
                });

            modelBuilder.Entity("Dominio.Enfermedad", b =>
                {
                    b.Navigation("EnfermedadClientes");
                });
#pragma warning restore 612, 618
        }
    }
}
