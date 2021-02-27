﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Patients.Data;

namespace Patients.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210227182407_RenameTableAddIndexMigration")]
    partial class RenameTableAddIndexMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("Patients.Data.Entities.DentalRecord", b =>
                {
                    b.Property<Guid>("PatientID")
                        .HasColumnType("TEXT");

                    b.Property<int>("Tooth11")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth12")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth13")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth14")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth15")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth16")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth17")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth18")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth21")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth22")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth23")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth24")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth25")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth26")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth27")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth28")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth31")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth32")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth33")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth34")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth35")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth36")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth37")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth38")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth41")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth42")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth43")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth44")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth45")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth46")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth47")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth48")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth51")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth52")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth53")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth54")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth55")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth61")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth62")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth63")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth64")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth65")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth71")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth72")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth73")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth74")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth75")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth81")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth82")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth83")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth84")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Tooth85")
                        .HasColumnType("INTEGER");

                    b.HasKey("PatientID");

                    b.ToTable("DentalRecords");
                });

            modelBuilder.Entity("Patients.Data.Entities.DiaryRecord", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Diagnosis")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PatientID")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("PatientID");

                    b.ToTable("DiaryRecords");
                });

            modelBuilder.Entity("Patients.Data.Entities.Patient", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Diagnosis")
                        .HasColumnType("TEXT");

                    b.Property<int>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("LastVisitDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("SecondName")
                        .HasColumnType("TEXT");

                    b.Property<int>("Storage")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Surname")
                        .HasColumnType("TEXT");

                    b.HasKey("ID");

                    b.HasIndex("Surname");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("Patients.Data.Entities.DentalRecord", b =>
                {
                    b.HasOne("Patients.Data.Entities.Patient", "Patient")
                        .WithOne("DentalRecord")
                        .HasForeignKey("Patients.Data.Entities.DentalRecord", "PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Patients.Data.Entities.DiaryRecord", b =>
                {
                    b.HasOne("Patients.Data.Entities.Patient", "Patient")
                        .WithMany("Diary")
                        .HasForeignKey("PatientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("Patients.Data.Entities.Patient", b =>
                {
                    b.Navigation("DentalRecord");

                    b.Navigation("Diary");
                });
#pragma warning restore 612, 618
        }
    }
}
