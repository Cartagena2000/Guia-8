﻿// <auto-generated />
using LibroAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibroAPI.Migrations
{
    [DbContext(typeof(LibroContext))]
    [Migration("20240901011019_Migración inicial")]
    partial class Migracióninicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibroAPI.Models.Libro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AnioPublicacion")
                        .HasColumnType("int");

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Libros");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AnioPublicacion = 1967,
                            Autor = "Gabriel García Márquez",
                            Titulo = "Cien años de soledad"
                        },
                        new
                        {
                            Id = 2,
                            AnioPublicacion = 1605,
                            Autor = "Miguel de Cervantes",
                            Titulo = "Don Quijote de la Mancha"
                        },
                        new
                        {
                            Id = 3,
                            AnioPublicacion = 1985,
                            Autor = "Gabriel García Márquez",
                            Titulo = "El amor en los tiempos del cólera"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
