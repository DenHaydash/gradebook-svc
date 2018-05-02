﻿// <auto-generated />
using GradeBook.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace GradeBook.DAL.Migrations
{
    [DbContext(typeof(GradebookContext))]
    partial class GradebookContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011");

            modelBuilder.Entity("GradeBook.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Login")
                        .IsRequired();

                    b.Property<string>("MiddleName")
                        .IsRequired();

                    b.Property<string>("PasswordHash")
                        .IsRequired();

                    b.Property<string>("PasswordSalt")
                        .IsRequired();

                    b.Property<string>("Role")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("GradeBook.Models.AssestmentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("AssestmentType");
                });

            modelBuilder.Entity("GradeBook.Models.FinalGrade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("GradebookRefId");

                    b.Property<int>("StudentRefId");

                    b.Property<int>("TeacherRefId");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.HasIndex("GradebookRefId");

                    b.HasIndex("StudentRefId");

                    b.HasIndex("TeacherRefId");

                    b.ToTable("FinalGrade");
                });

            modelBuilder.Entity("GradeBook.Models.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("GradebookRefId");

                    b.Property<int>("StudentRefId");

                    b.Property<int>("TeacherRefId");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.HasIndex("GradebookRefId");

                    b.HasIndex("StudentRefId");

                    b.HasIndex("TeacherRefId");

                    b.ToTable("Grade");
                });

            modelBuilder.Entity("GradeBook.Models.Gradebook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SemesterRefId");

                    b.Property<int>("SubjectRefId");

                    b.HasKey("Id");

                    b.HasIndex("SubjectRefId");

                    b.HasIndex("SemesterRefId", "SubjectRefId");

                    b.ToTable("Gradebooks");
                });

            modelBuilder.Entity("GradeBook.Models.GradebookTeacher", b =>
                {
                    b.Property<int>("GradebookRefId");

                    b.Property<int>("TeacherRefId");

                    b.HasKey("GradebookRefId", "TeacherRefId");

                    b.HasIndex("TeacherRefId");

                    b.ToTable("GradebookTeacher");
                });

            modelBuilder.Entity("GradeBook.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<DateTime>("EducationStartedAt");

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("SpecialityRefId");

                    b.HasKey("Id");

                    b.HasIndex("SpecialityRefId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("GradeBook.Models.Semester", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseNumber");

                    b.Property<DateTime>("EndsAt");

                    b.Property<int>("GroupRefId");

                    b.Property<int>("SemesterNumber");

                    b.Property<DateTime>("StartsAt");

                    b.HasKey("Id");

                    b.HasIndex("GroupRefId");

                    b.ToTable("Semester");
                });

            modelBuilder.Entity("GradeBook.Models.SemesterSubject", b =>
                {
                    b.Property<int>("SemesterRefId");

                    b.Property<int>("SubjectRefId");

                    b.Property<int>("AssestemtTypeRefId");

                    b.HasKey("SemesterRefId", "SubjectRefId");

                    b.HasIndex("AssestemtTypeRefId");

                    b.HasIndex("SubjectRefId");

                    b.ToTable("SemesterSubject");
                });

            modelBuilder.Entity("GradeBook.Models.Specialty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Specialty");
                });

            modelBuilder.Entity("GradeBook.Models.Student", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("GroupRefId");

                    b.Property<bool>("IsDeleted");

                    b.HasKey("Id");

                    b.HasIndex("GroupRefId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("GradeBook.Models.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("GradeBook.Models.Teacher", b =>
                {
                    b.Property<int>("Id");

                    b.Property<bool>("IsDeleted");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("GradeBook.Models.FinalGrade", b =>
                {
                    b.HasOne("GradeBook.Models.Gradebook", "Gradebook")
                        .WithMany("FinalGrades")
                        .HasForeignKey("GradebookRefId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GradeBook.Models.Student", "Student")
                        .WithMany("FinalGrades")
                        .HasForeignKey("StudentRefId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GradeBook.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherRefId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GradeBook.Models.Grade", b =>
                {
                    b.HasOne("GradeBook.Models.Gradebook", "Gradebook")
                        .WithMany("Grades")
                        .HasForeignKey("GradebookRefId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GradeBook.Models.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentRefId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GradeBook.Models.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherRefId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GradeBook.Models.Gradebook", b =>
                {
                    b.HasOne("GradeBook.Models.Semester", "Semester")
                        .WithMany()
                        .HasForeignKey("SemesterRefId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GradeBook.Models.Subject", "Subject")
                        .WithMany()
                        .HasForeignKey("SubjectRefId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GradeBook.Models.SemesterSubject", "SemesterSubject")
                        .WithMany()
                        .HasForeignKey("SemesterRefId", "SubjectRefId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GradeBook.Models.GradebookTeacher", b =>
                {
                    b.HasOne("GradeBook.Models.Gradebook", "Gradebook")
                        .WithMany("GradebookTeachers")
                        .HasForeignKey("GradebookRefId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GradeBook.Models.Teacher", "Teacher")
                        .WithMany("GradebookTeachers")
                        .HasForeignKey("TeacherRefId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GradeBook.Models.Group", b =>
                {
                    b.HasOne("GradeBook.Models.Specialty", "Specialty")
                        .WithMany("Groups")
                        .HasForeignKey("SpecialityRefId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GradeBook.Models.Semester", b =>
                {
                    b.HasOne("GradeBook.Models.Group", "Group")
                        .WithMany("Semesters")
                        .HasForeignKey("GroupRefId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GradeBook.Models.SemesterSubject", b =>
                {
                    b.HasOne("GradeBook.Models.AssestmentType", "AssestmentType")
                        .WithMany()
                        .HasForeignKey("AssestemtTypeRefId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GradeBook.Models.Semester", "Semester")
                        .WithMany("SemesterSubjects")
                        .HasForeignKey("SemesterRefId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GradeBook.Models.Subject", "Subject")
                        .WithMany("Semesters")
                        .HasForeignKey("SubjectRefId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GradeBook.Models.Student", b =>
                {
                    b.HasOne("GradeBook.Models.Group", "Group")
                        .WithMany("Students")
                        .HasForeignKey("GroupRefId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GradeBook.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GradeBook.Models.Teacher", b =>
                {
                    b.HasOne("GradeBook.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
