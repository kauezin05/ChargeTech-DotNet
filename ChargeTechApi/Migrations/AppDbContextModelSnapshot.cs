﻿// <auto-generated />
using System;
using ChargeTechApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace ChargeTechApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ChargeTechApi.Models.Ambiente", b =>
                {
                    b.Property<int>("ID_AMBIENTE")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_AMBIENTE"));

                    b.Property<string>("DESC_AMBIENTE")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("NM_AMBIENTE")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("ID_AMBIENTE");

                    b.ToTable("CT_AMBIENTE");
                });

            modelBuilder.Entity("ChargeTechApi.Models.ConsumoEnergetico", b =>
                {
                    b.Property<int>("ID_CONSUMO_ENERGETICO")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_CONSUMO_ENERGETICO"));

                    b.Property<double>("CONSUMO")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<decimal>("CUSTO_CONSUMO")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<decimal>("CUSTO_ESTIMADO")
                        .HasColumnType("DECIMAL(18, 2)");

                    b.Property<DateTime>("DATA_REGISTRO")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<int>("ID_DISPOSITIVO")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("ID_CONSUMO_ENERGETICO");

                    b.HasIndex("ID_DISPOSITIVO");

                    b.ToTable("CT_CONSUMO_ENERGETICO");
                });

            modelBuilder.Entity("ChargeTechApi.Models.Dispositivo", b =>
                {
                    b.Property<int>("ID_DISPOSITIVO")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_DISPOSITIVO"));

                    b.Property<double>("CONSUMO_MEDIO")
                        .HasColumnType("BINARY_DOUBLE");

                    b.Property<int>("ID_AMBIENTE")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("ID_USUARIO")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("IMAGEM_DISPOSITIVO")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("NM_DISPOSITIVO")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("STATUS")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("ID_DISPOSITIVO");

                    b.HasIndex("ID_AMBIENTE");

                    b.HasIndex("ID_USUARIO");

                    b.ToTable("CT_DISPOSITIVO");
                });

            modelBuilder.Entity("ChargeTechApi.Models.Usuario", b =>
                {
                    b.Property<int>("ID_USUARIO")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID_USUARIO"));

                    b.Property<DateTime>("DT_NASCIMENTO_USUARIO")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("EMAIL_USUARIO")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("NM_USUARIO")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("SENHA_USUARIO")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("ID_USUARIO");

                    b.ToTable("CT_USUARIO");
                });

            modelBuilder.Entity("ChargeTechApi.Models.ConsumoEnergetico", b =>
                {
                    b.HasOne("ChargeTechApi.Models.Dispositivo", null)
                        .WithMany()
                        .HasForeignKey("ID_DISPOSITIVO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ChargeTechApi.Models.Dispositivo", b =>
                {
                    b.HasOne("ChargeTechApi.Models.Ambiente", null)
                        .WithMany()
                        .HasForeignKey("ID_AMBIENTE")
                        .OnDelete(DeleteBehavior.SetNull)
                        .IsRequired();

                    b.HasOne("ChargeTechApi.Models.Usuario", null)
                        .WithMany()
                        .HasForeignKey("ID_USUARIO")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
