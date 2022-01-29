﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(UniversityContext))]
    [Migration("20220125154943_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.Guarantor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AcademicDegree")
                        .HasColumnType("text");

                    b.Property<string>("AcademicRank")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Guarantors");
                });

            modelBuilder.Entity("Core.Entities.HeadOfSmc", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AcademicDegree")
                        .HasColumnType("text");

                    b.Property<string>("AcademicRank")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("HeadsOfSmc");
                });

            modelBuilder.Entity("Core.Entities.KnowledgeBranch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("KnowledgeBranches");
                });

            modelBuilder.Entity("Core.Entities.Specialty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("GuarantorId")
                        .HasColumnType("integer");

                    b.Property<int>("HeadOfSMCId")
                        .HasColumnType("integer");

                    b.Property<int>("KnowledgeBranchId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("GuarantorId")
                        .IsUnique();

                    b.HasIndex("HeadOfSMCId");

                    b.HasIndex("KnowledgeBranchId");

                    b.ToTable("Specialties");
                });

            modelBuilder.Entity("Core.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("Core.Entities.Syllabus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ClassroomHours")
                        .HasColumnType("integer");

                    b.Property<byte?>("CourseProjects")
                        .HasColumnType("smallint");

                    b.Property<byte?>("CourseWork")
                        .HasColumnType("smallint");

                    b.Property<string>("Credits")
                        .HasColumnType("text");

                    b.Property<string>("FormOfControl")
                        .HasColumnType("text");

                    b.Property<int?>("LabHours")
                        .HasColumnType("integer");

                    b.Property<int?>("LectureHours")
                        .HasColumnType("integer");

                    b.Property<int?>("PracticalHours")
                        .HasColumnType("integer");

                    b.Property<byte?>("R")
                        .HasColumnType("smallint");

                    b.Property<byte?>("RGR")
                        .HasColumnType("smallint");

                    b.Property<byte?>("Semester")
                        .HasColumnType("smallint");

                    b.Property<int?>("TotalHours")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Syllabuses");
                });

            modelBuilder.Entity("Core.Entities.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AcademicDegree")
                        .HasColumnType("text");

                    b.Property<string>("AcademicRank")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Core.Entities.TeacherLoad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("SpecialtyId")
                        .HasColumnType("integer");

                    b.Property<int>("SubjectId")
                        .HasColumnType("integer");

                    b.Property<int>("SyllabusId")
                        .HasColumnType("integer");

                    b.Property<int>("TeacherId")
                        .HasColumnType("integer");

                    b.Property<byte>("Type")
                        .HasColumnType("smallint");

                    b.Property<byte>("Year")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("SpecialtyId");

                    b.HasIndex("SubjectId");

                    b.HasIndex("SyllabusId");

                    b.HasIndex("TeacherId");

                    b.HasIndex("Type", "Year", "TeacherId", "SubjectId", "SpecialtyId")
                        .IsUnique();

                    b.ToTable("TeacherLoads");
                });

            modelBuilder.Entity("Core.Entities.Specialty", b =>
                {
                    b.HasOne("Core.Entities.Guarantor", "Guarantor")
                        .WithOne("Specialty")
                        .HasForeignKey("Core.Entities.Specialty", "GuarantorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.HeadOfSmc", "HeadOfSMC")
                        .WithMany("Specialties")
                        .HasForeignKey("HeadOfSMCId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.KnowledgeBranch", "KnowledgeBranch")
                        .WithMany("Specialties")
                        .HasForeignKey("KnowledgeBranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Guarantor");

                    b.Navigation("HeadOfSMC");

                    b.Navigation("KnowledgeBranch");
                });

            modelBuilder.Entity("Core.Entities.TeacherLoad", b =>
                {
                    b.HasOne("Core.Entities.Specialty", "Specialty")
                        .WithMany("TeacherLoads")
                        .HasForeignKey("SpecialtyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Subject", "Subject")
                        .WithMany("TeacherLoads")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Syllabus", "Syllabus")
                        .WithMany("TeacherLoads")
                        .HasForeignKey("SyllabusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Teacher", "Teacher")
                        .WithMany("TeacherLoads")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Specialty");

                    b.Navigation("Subject");

                    b.Navigation("Syllabus");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("Core.Entities.Guarantor", b =>
                {
                    b.Navigation("Specialty");
                });

            modelBuilder.Entity("Core.Entities.HeadOfSmc", b =>
                {
                    b.Navigation("Specialties");
                });

            modelBuilder.Entity("Core.Entities.KnowledgeBranch", b =>
                {
                    b.Navigation("Specialties");
                });

            modelBuilder.Entity("Core.Entities.Specialty", b =>
                {
                    b.Navigation("TeacherLoads");
                });

            modelBuilder.Entity("Core.Entities.Subject", b =>
                {
                    b.Navigation("TeacherLoads");
                });

            modelBuilder.Entity("Core.Entities.Syllabus", b =>
                {
                    b.Navigation("TeacherLoads");
                });

            modelBuilder.Entity("Core.Entities.Teacher", b =>
                {
                    b.Navigation("TeacherLoads");
                });
#pragma warning restore 612, 618
        }
    }
}