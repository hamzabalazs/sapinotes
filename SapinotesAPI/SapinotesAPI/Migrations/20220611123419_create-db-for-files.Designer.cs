﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SapinotesAPI.Data;

#nullable disable

namespace SapinotesAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220611123419_create-db-for-files")]
    partial class createdbforfiles
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("SapinotesAPI.Data.Models.Document", b =>
                {
                    b.Property<int>("documentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("documentID"), 1L, 1);

                    b.Property<string>("documentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("documentSize")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.HasKey("documentID");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("SapinotesAPI.Data.Models.Major", b =>
                {
                    b.Property<int>("majorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("majorID"), 1L, 1);

                    b.Property<string>("majorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("majorID");

                    b.ToTable("Majors");
                });

            modelBuilder.Entity("SapinotesAPI.Data.Models.Note", b =>
                {
                    b.Property<int>("noteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("noteID"), 1L, 1);

                    b.Property<int>("noteDocID")
                        .HasColumnType("int");

                    b.Property<string>("noteName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("subjectID")
                        .HasColumnType("int");

                    b.Property<int>("userID")
                        .HasColumnType("int");

                    b.HasKey("noteID");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("SapinotesAPI.Data.Models.Subject", b =>
                {
                    b.Property<int>("subjectID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("subjectID"), 1L, 1);

                    b.Property<int>("majorID")
                        .HasColumnType("int");

                    b.Property<string>("subjectName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("subjectID");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("SapinotesAPI.Data.Models.User", b =>
                {
                    b.Property<int>("userID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userID"), 1L, 1);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userID");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}