﻿// <auto-generated />
using System;
using Laboratory.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Laboratory.Persistence.Migrations
{
    [DbContext(typeof(LaboratoryContext))]
    [Migration("20220513112223_addedCompany")]
    partial class addedCompany
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Laboratory.Domain.Aggregates.Company", b =>
                {
                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("CompanyCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("CompanyId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Laboratory.Domain.Aggregates.ConcreteCubeStrengthTest", b =>
                {
                    b.Property<Guid>("ConcreteCubeStrengthTestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AcceptedSampleCount")
                        .HasColumnType("int");

                    b.Property<decimal>("AverageCrushForce")
                        .HasPrecision(15, 5)
                        .HasColumnType("decimal(15,5)");

                    b.Property<decimal>("CharacteristicStrength")
                        .HasPrecision(15, 5)
                        .HasColumnType("decimal(15,5)");

                    b.Property<Guid>("ClientCompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcreteRating")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ConcreteType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("EmployeeCompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ExtendedUncertainty")
                        .HasPrecision(15, 5)
                        .HasColumnType("decimal(15,5)");

                    b.Property<Guid>("ProtocolCreatedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("RejectedSampleCount")
                        .HasColumnType("int");

                    b.Property<decimal>("StandardDeviation")
                        .HasPrecision(15, 5)
                        .HasColumnType("decimal(15,5)");

                    b.Property<decimal>("StandardUncertainty")
                        .HasPrecision(15, 5)
                        .HasColumnType("decimal(15,5)");

                    b.Property<Guid>("TestExecutedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTimeOffset>("TestExecutionDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("TestProtocolNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TestSamplesReceivedBy")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("TestSamplesReceivedComment")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<int>("TestSamplesReceivedCount")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("TestSamplesReceivedDate")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("TestType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ConcreteCubeStrengthTestId");

                    b.ToTable("StrengthTest", "ConcreteCube");
                });

            modelBuilder.Entity("Laboratory.Domain.Entities.Company.ConstructionSite", b =>
                {
                    b.Property<Guid>("ConstructionSiteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<Guid?>("CompanyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("ConstructionSiteId");

                    b.HasIndex("CompanyId");

                    b.ToTable("ConstructionSite");
                });

            modelBuilder.Entity("Laboratory.Domain.Entities.ConcreteCube.ConcreteCubeStrengthTestData", b =>
                {
                    b.Property<Guid>("ConcreteCubeStrengthTestDataId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<Guid?>("ConcreteCubeStrengthTestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("CrushingStrength")
                        .HasPrecision(15, 5)
                        .HasColumnType("decimal(15,5)");

                    b.Property<decimal>("DestructivePower")
                        .HasPrecision(15, 5)
                        .HasColumnType("decimal(15,5)");

                    b.HasKey("ConcreteCubeStrengthTestDataId");

                    b.HasIndex("ConcreteCubeStrengthTestId");

                    b.ToTable("StrengthTestData", "ConcreteCube");
                });

            modelBuilder.Entity("Laboratory.Domain.Entities.ConcreteCube.CrossSectionalDimensions", b =>
                {
                    b.Property<Guid>("CrossSectionalDimensionsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ConcreteCubeStrengthTestDataId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Dimension")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Value")
                        .HasPrecision(15, 5)
                        .HasColumnType("decimal(15,5)");

                    b.HasKey("CrossSectionalDimensionsId");

                    b.HasIndex("ConcreteCubeStrengthTestDataId");

                    b.ToTable("CrossSectionalDimensions", "ConcreteCube");
                });

            modelBuilder.Entity("Laboratory.Domain.Entities.Company.ConstructionSite", b =>
                {
                    b.HasOne("Laboratory.Domain.Aggregates.Company", null)
                        .WithMany("ConstructionSites")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Laboratory.Domain.Entities.ConcreteCube.ConcreteCubeStrengthTestData", b =>
                {
                    b.HasOne("Laboratory.Domain.Aggregates.ConcreteCubeStrengthTest", null)
                        .WithMany("TestData")
                        .HasForeignKey("ConcreteCubeStrengthTestId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Laboratory.Domain.Entities.ConcreteCube.CrossSectionalDimensions", b =>
                {
                    b.HasOne("Laboratory.Domain.Entities.ConcreteCube.ConcreteCubeStrengthTestData", null)
                        .WithMany("Dimensions")
                        .HasForeignKey("ConcreteCubeStrengthTestDataId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Laboratory.Domain.Aggregates.Company", b =>
                {
                    b.Navigation("ConstructionSites");
                });

            modelBuilder.Entity("Laboratory.Domain.Aggregates.ConcreteCubeStrengthTest", b =>
                {
                    b.Navigation("TestData");
                });

            modelBuilder.Entity("Laboratory.Domain.Entities.ConcreteCube.ConcreteCubeStrengthTestData", b =>
                {
                    b.Navigation("Dimensions");
                });
#pragma warning restore 612, 618
        }
    }
}
