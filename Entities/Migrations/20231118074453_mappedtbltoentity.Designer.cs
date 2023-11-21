﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Entities.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231118074453_mappedtbltoentity")]
    partial class mappedtbltoentity
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.EntityClass", b =>
                {
                    b.Property<string>("EntityName")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EntityName");

                    b.ToTable("EntityTbl", (string)null);

                    b.HasData(
                        new
                        {
                            EntityName = "Driver",
                            Description = "This driver entity contains features for driver data"
                        },
                        new
                        {
                            EntityName = "Character",
                            Description = "This character entity contains features for Character data "
                        },
                        new
                        {
                            EntityName = "Stock",
                            Description = "This Stock entity contains features for Stock data"
                        });
                });

            modelBuilder.Entity("Entities.FeatureClass", b =>
                {
                    b.Property<int>("FeatureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FeatureID"));

                    b.Property<string>("AdminComments")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("ApprovalStatus")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("EntityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FeatureDataType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FeatureName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FeatureID");

                    b.HasIndex("EntityName");

                    b.ToTable("Features");

                    b.HasData(
                        new
                        {
                            FeatureID = 1,
                            AdminComments = "good",
                            ApprovalStatus = (byte)0,
                            CreatedAt = new DateTime(2023, 11, 18, 13, 14, 53, 463, DateTimeKind.Local).AddTicks(2738),
                            EntityName = "Driver",
                            FeatureDataType = "double",
                            FeatureName = "Rating",
                            UserID = 0,
                            Value = "4.8"
                        },
                        new
                        {
                            FeatureID = 2,
                            AdminComments = "good",
                            ApprovalStatus = (byte)0,
                            CreatedAt = new DateTime(2023, 11, 18, 13, 14, 53, 463, DateTimeKind.Local).AddTicks(2752),
                            EntityName = "Driver",
                            FeatureDataType = "int",
                            FeatureName = "TripsToday",
                            UserID = 0,
                            Value = "12"
                        },
                        new
                        {
                            FeatureID = 3,
                            AdminComments = "good",
                            ApprovalStatus = (byte)0,
                            CreatedAt = new DateTime(2023, 11, 18, 13, 14, 53, 463, DateTimeKind.Local).AddTicks(2754),
                            EntityName = "Character",
                            FeatureDataType = "double",
                            FeatureName = "Height",
                            UserID = 0,
                            Value = "5.2"
                        },
                        new
                        {
                            FeatureID = 4,
                            AdminComments = "good",
                            ApprovalStatus = (byte)0,
                            CreatedAt = new DateTime(2023, 11, 18, 13, 14, 53, 463, DateTimeKind.Local).AddTicks(2797),
                            EntityName = "Character",
                            FeatureDataType = "double",
                            FeatureName = "Width",
                            UserID = 0,
                            Value = "12.6"
                        },
                        new
                        {
                            FeatureID = 5,
                            AdminComments = "good",
                            ApprovalStatus = (byte)0,
                            CreatedAt = new DateTime(2023, 11, 18, 13, 14, 53, 463, DateTimeKind.Local).AddTicks(2799),
                            EntityName = "Stock",
                            FeatureDataType = "double",
                            FeatureName = "Price",
                            UserID = 0,
                            Value = "2444.12"
                        });
                });

            modelBuilder.Entity("Entities.FeatureClass", b =>
                {
                    b.HasOne("Entities.EntityClass", "Entity")
                        .WithMany("Features")
                        .HasForeignKey("EntityName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entity");
                });

            modelBuilder.Entity("Entities.EntityClass", b =>
                {
                    b.Navigation("Features");
                });
#pragma warning restore 612, 618
        }
    }
}
