﻿// <auto-generated />
using System;
using API_B.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API_B.Migrations
{
    [DbContext(typeof(FolhaContext))]
    [Migration("20230629215105_primeira")]
    partial class primeira
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("API_B.Model.Folha", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ano")
                        .HasColumnType("INTEGER");

                    b.Property<float?>("bruto")
                        .HasColumnType("REAL");

                    b.Property<string>("cpf")
                        .HasColumnType("TEXT");

                    b.Property<float?>("fgts")
                        .HasColumnType("REAL");

                    b.Property<float?>("horas")
                        .HasColumnType("REAL");

                    b.Property<float?>("inss")
                        .HasColumnType("REAL");

                    b.Property<float?>("irrf")
                        .HasColumnType("REAL");

                    b.Property<float?>("liquido")
                        .HasColumnType("REAL");

                    b.Property<int?>("mes")
                        .HasColumnType("INTEGER");

                    b.Property<string>("nome")
                        .HasColumnType("TEXT");

                    b.Property<float?>("valor")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Folhas");
                });
#pragma warning restore 612, 618
        }
    }
}
