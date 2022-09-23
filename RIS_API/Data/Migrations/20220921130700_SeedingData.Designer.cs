﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RIS_API.Data;

#nullable disable

namespace RIS_API.Data.Migrations
{
    [DbContext(typeof(RISDbContext))]
    [Migration("20220921130700_SeedingData")]
    partial class SeedingData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RIS_API.Data.HL7Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Accessionnumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("Insertdate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Modalityid")
                        .HasColumnType("int");

                    b.Property<int?>("ModalitytypeId")
                        .HasColumnType("int");

                    b.Property<int>("Patientid")
                        .HasColumnType("int");

                    b.Property<int>("Proceduretypeid")
                        .HasColumnType("int");

                    b.Property<DateTime>("Startdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Studyid")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Modalityid");

                    b.HasIndex("ModalitytypeId");

                    b.HasIndex("Patientid");

                    b.HasIndex("Proceduretypeid");

                    b.ToTable("HL7Messages");
                });

            modelBuilder.Entity("RIS_API.Data.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Middlename")
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Mothername")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatientId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Ris2022.Data.Models.Modality", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AeTitle")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("Modalitytypeid")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<int?>("Port")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Modalitytypeid");

                    b.ToTable("Modalities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AeTitle = "CRModAE",
                            Description = "CR Modality",
                            IpAddress = "127.0.0.1",
                            Modalitytypeid = 1,
                            Name = "CR_Modality",
                            Port = 104
                        },
                        new
                        {
                            Id = 2,
                            AeTitle = "MRModAE",
                            Description = "MR Modality",
                            IpAddress = "127.0.0.1",
                            Modalitytypeid = 1,
                            Name = "MR_Modality",
                            Port = 104
                        });
                });

            modelBuilder.Entity("Ris2022.Data.Models.Modalitytype", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Modalitytypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "CR"
                        },
                        new
                        {
                            Id = 2,
                            Name = "DR"
                        });
                });

            modelBuilder.Entity("Ris2022.Data.Models.Proceduretype", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Proceduretypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Shoulder"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Head"
                        });
                });

            modelBuilder.Entity("RIS_API.Data.HL7Message", b =>
                {
                    b.HasOne("Ris2022.Data.Models.Modality", "modality")
                        .WithMany("HL7Messages")
                        .HasForeignKey("Modalityid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ris2022.Data.Models.Modalitytype", null)
                        .WithMany("HL7Messages")
                        .HasForeignKey("ModalitytypeId");

                    b.HasOne("RIS_API.Data.Patient", "patient")
                        .WithMany("patientHL7Msgs")
                        .HasForeignKey("Patientid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ris2022.Data.Models.Proceduretype", "proceduretype")
                        .WithMany("HL7Messages")
                        .HasForeignKey("Proceduretypeid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("modality");

                    b.Navigation("patient");

                    b.Navigation("proceduretype");
                });

            modelBuilder.Entity("Ris2022.Data.Models.Modality", b =>
                {
                    b.HasOne("Ris2022.Data.Models.Modalitytype", "Modalitytype")
                        .WithMany()
                        .HasForeignKey("Modalitytypeid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Modalitytype");
                });

            modelBuilder.Entity("RIS_API.Data.Patient", b =>
                {
                    b.Navigation("patientHL7Msgs");
                });

            modelBuilder.Entity("Ris2022.Data.Models.Modality", b =>
                {
                    b.Navigation("HL7Messages");
                });

            modelBuilder.Entity("Ris2022.Data.Models.Modalitytype", b =>
                {
                    b.Navigation("HL7Messages");
                });

            modelBuilder.Entity("Ris2022.Data.Models.Proceduretype", b =>
                {
                    b.Navigation("HL7Messages");
                });
#pragma warning restore 612, 618
        }
    }
}