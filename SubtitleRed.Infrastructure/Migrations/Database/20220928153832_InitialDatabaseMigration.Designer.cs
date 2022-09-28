﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SubtitleRed.Infrastructure.DataAccess.Context;

#nullable disable

namespace SubtitleRed.Infrastructure.Migrations.Database
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20220928153832_InitialDatabaseMigration")]
    partial class InitialDatabaseMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SubtitleRed.Domain.Lines.Line", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("LineOrder")
                        .HasColumnType("int");

                    b.Property<Guid>("SectionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Speaker")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("SectionId");

                    b.ToTable("Lines");
                });

            modelBuilder.Entity("SubtitleRed.Domain.Scenes.Scene", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Scenes");
                });

            modelBuilder.Entity("SubtitleRed.Domain.Sections.Section", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SceneId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("SectionOrder")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SceneId");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("SubtitleRed.Domain.Lines.Line", b =>
                {
                    b.HasOne("SubtitleRed.Domain.Sections.Section", null)
                        .WithMany("Lines")
                        .HasForeignKey("SectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SubtitleRed.Domain.Sections.Section", b =>
                {
                    b.HasOne("SubtitleRed.Domain.Scenes.Scene", null)
                        .WithMany("Sections")
                        .HasForeignKey("SceneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SubtitleRed.Domain.Scenes.Scene", b =>
                {
                    b.Navigation("Sections");
                });

            modelBuilder.Entity("SubtitleRed.Domain.Sections.Section", b =>
                {
                    b.Navigation("Lines");
                });
#pragma warning restore 612, 618
        }
    }
}
