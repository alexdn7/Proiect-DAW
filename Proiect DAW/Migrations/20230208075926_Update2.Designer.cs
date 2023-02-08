﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect_DAW.Data;

namespace Proiect_DAW.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230208075926_Update2")]
    partial class Update2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Proiect_DAW.Models.Locatie", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Oras")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Strada")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tara")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Locatii");
                });

            modelBuilder.Entity("Proiect_DAW.Models.Producator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descriere")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("LocatieId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LocatieId")
                        .IsUnique();

                    b.ToTable("Producatori");
                });

            modelBuilder.Entity("Proiect_DAW.Models.Produs", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Denumire")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descriere")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Pret")
                        .HasColumnType("float");

                    b.Property<Guid?>("ProducatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Stoc")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProducatorId");

                    b.ToTable("Produse");
                });

            modelBuilder.Entity("Proiect_DAW.Models.Produs_Vanzator", b =>
                {
                    b.Property<Guid>("ProdusId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VanzatorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProdusId", "VanzatorId");

                    b.HasIndex("VanzatorId");

                    b.ToTable("Produse_Vanzatori");
                });

            modelBuilder.Entity("Proiect_DAW.Models.Vanzator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vanzatori");
                });

            modelBuilder.Entity("Proiect_DAW.Models.Producator", b =>
                {
                    b.HasOne("Proiect_DAW.Models.Locatie", "Locatie")
                        .WithOne("Producator")
                        .HasForeignKey("Proiect_DAW.Models.Producator", "LocatieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Locatie");
                });

            modelBuilder.Entity("Proiect_DAW.Models.Produs", b =>
                {
                    b.HasOne("Proiect_DAW.Models.Producator", "Producator")
                        .WithMany("Produse")
                        .HasForeignKey("ProducatorId");

                    b.Navigation("Producator");
                });

            modelBuilder.Entity("Proiect_DAW.Models.Produs_Vanzator", b =>
                {
                    b.HasOne("Proiect_DAW.Models.Produs", "Produs")
                        .WithMany("Produs_Vanzator")
                        .HasForeignKey("ProdusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proiect_DAW.Models.Vanzator", "Vanzator")
                        .WithMany("Produs_Vanzator")
                        .HasForeignKey("VanzatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produs");

                    b.Navigation("Vanzator");
                });

            modelBuilder.Entity("Proiect_DAW.Models.Locatie", b =>
                {
                    b.Navigation("Producator");
                });

            modelBuilder.Entity("Proiect_DAW.Models.Producator", b =>
                {
                    b.Navigation("Produse");
                });

            modelBuilder.Entity("Proiect_DAW.Models.Produs", b =>
                {
                    b.Navigation("Produs_Vanzator");
                });

            modelBuilder.Entity("Proiect_DAW.Models.Vanzator", b =>
                {
                    b.Navigation("Produs_Vanzator");
                });
#pragma warning restore 612, 618
        }
    }
}
