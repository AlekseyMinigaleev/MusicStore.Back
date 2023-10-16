﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicStore.DB.DataAccess;

#nullable disable

namespace MusicStore.DB.Migrations
{
    [DbContext(typeof(MusicStoreDbContext))]
    partial class MusicStoreDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EnsembleMusicant", b =>
                {
                    b.Property<Guid>("EnsemblesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MusicantsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EnsemblesId", "MusicantsId");

                    b.HasIndex("MusicantsId");

                    b.ToTable("EnsambleMusicant", (string)null);
                });

            modelBuilder.Entity("MusicStore.DB.Models.CompactDisk", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CountInStock")
                        .HasColumnType("int");

                    b.Property<int>("CountSoldCurrentYear")
                        .HasColumnType("int");

                    b.Property<int?>("CountSoldPreviousYear")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ManufacturingCompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MusicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RetailPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("WhosalerPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturingCompanyId");

                    b.HasIndex("MusicId");

                    b.ToTable("CompactDisk", (string)null);
                });

            modelBuilder.Entity("MusicStore.DB.Models.Ensemble", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ensemble", (string)null);
                });

            modelBuilder.Entity("MusicStore.DB.Models.ManufacturingCompany", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ManufactoringCompany", (string)null);
                });

            modelBuilder.Entity("MusicStore.DB.Models.Music", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Music", (string)null);
                });

            modelBuilder.Entity("MusicStore.DB.Models.MusicalMetadata", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Duration")
                        .HasColumnType("float");

                    b.Property<string>("Interpretation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PerformanceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Tempo")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PerformanceId")
                        .IsUnique();

                    b.ToTable("MusicalMetadata", (string)null);
                });

            modelBuilder.Entity("MusicStore.DB.Models.Musicant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MusicalInstrument")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronomyc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Musicant", (string)null);
                });

            modelBuilder.Entity("MusicStore.DB.Models.Performance", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EnsembleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MusicId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("MusicalMetadataId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MusicId");

                    b.ToTable("Performance", (string)null);
                });

            modelBuilder.Entity("MusicStore.DB.Models.Songwriter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Patronomyc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Songwriter", (string)null);
                });

            modelBuilder.Entity("EnsembleMusicant", b =>
                {
                    b.HasOne("MusicStore.DB.Models.Ensemble", null)
                        .WithMany()
                        .HasForeignKey("EnsemblesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicStore.DB.Models.Musicant", null)
                        .WithMany()
                        .HasForeignKey("MusicantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MusicStore.DB.Models.CompactDisk", b =>
                {
                    b.HasOne("MusicStore.DB.Models.ManufacturingCompany", "ManufacturingCompany")
                        .WithMany("ManufacturedDisks")
                        .HasForeignKey("ManufacturingCompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicStore.DB.Models.Music", "Music")
                        .WithMany("CompactDisks")
                        .HasForeignKey("MusicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ManufacturingCompany");

                    b.Navigation("Music");
                });

            modelBuilder.Entity("MusicStore.DB.Models.Music", b =>
                {
                    b.HasOne("MusicStore.DB.Models.Songwriter", "Autor")
                        .WithMany("Musics")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Autor");
                });

            modelBuilder.Entity("MusicStore.DB.Models.MusicalMetadata", b =>
                {
                    b.HasOne("MusicStore.DB.Models.Performance", "Performance")
                        .WithOne("MusicalMetadata")
                        .HasForeignKey("MusicStore.DB.Models.MusicalMetadata", "PerformanceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Performance");
                });

            modelBuilder.Entity("MusicStore.DB.Models.Performance", b =>
                {
                    b.HasOne("MusicStore.DB.Models.Ensemble", "Ensemble")
                        .WithMany("Performances")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicStore.DB.Models.Music", "Music")
                        .WithMany("Performances")
                        .HasForeignKey("MusicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ensemble");

                    b.Navigation("Music");
                });

            modelBuilder.Entity("MusicStore.DB.Models.Ensemble", b =>
                {
                    b.Navigation("Performances");
                });

            modelBuilder.Entity("MusicStore.DB.Models.ManufacturingCompany", b =>
                {
                    b.Navigation("ManufacturedDisks");
                });

            modelBuilder.Entity("MusicStore.DB.Models.Music", b =>
                {
                    b.Navigation("CompactDisks");

                    b.Navigation("Performances");
                });

            modelBuilder.Entity("MusicStore.DB.Models.Performance", b =>
                {
                    b.Navigation("MusicalMetadata")
                        .IsRequired();
                });

            modelBuilder.Entity("MusicStore.DB.Models.Songwriter", b =>
                {
                    b.Navigation("Musics");
                });
#pragma warning restore 612, 618
        }
    }
}
