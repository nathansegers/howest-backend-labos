﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using labo02.data;

namespace labo02.Migrations
{
    [DbContext(typeof(RegistrationContext))]
    [Migration("20210303132630_Test")]
    partial class Test
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("labo02.Models.VaccinType", b =>
                {
                    b.Property<Guid>("VaccinTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VaccinTypeId");

                    b.ToTable("VaccinTypes");
                });

            modelBuilder.Entity("labo02.Models.VaccinationLocation", b =>
                {
                    b.Property<Guid>("VaccinationLocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VaccinationLocationId");

                    b.ToTable("VaccinationLocation");
                });

            modelBuilder.Entity("labo02.Models.VaccinationRegistration", b =>
                {
                    b.Property<Guid>("VaccinationRegistrationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("VaccinTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("VaccinationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("VaccinationLocationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("VaccinationRegistrationId");

                    b.ToTable("VaccininationRegistration");
                });
#pragma warning restore 612, 618
        }
    }
}
