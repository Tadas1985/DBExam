﻿// <auto-generated />
using System;
using DBexam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DBexam.Migrations
{
    [DbContext(typeof(UniversityContext))]
    [Migration("20220421170124_Update4")]
    partial class Update4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DBexam.Models.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("DepartmentSet");
                });

            modelBuilder.Entity("DBexam.Models.Lecture", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LectureSet");
                });

            modelBuilder.Entity("DBexam.Models.Student", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DPId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DPId");

                    b.ToTable("StudentSet");
                });

            modelBuilder.Entity("DepartmentLecture", b =>
                {
                    b.Property<Guid>("DeparetmentsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LecturesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("DeparetmentsId", "LecturesId");

                    b.HasIndex("LecturesId");

                    b.ToTable("DepartmentLecture");
                });

            modelBuilder.Entity("LectureStudent", b =>
                {
                    b.Property<Guid>("LecturesListId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("StudentsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LecturesListId", "StudentsId");

                    b.HasIndex("StudentsId");

                    b.ToTable("LectureStudent");
                });

            modelBuilder.Entity("DBexam.Models.Student", b =>
                {
                    b.HasOne("DBexam.Models.Department", "DP")
                        .WithMany("Students")
                        .HasForeignKey("DPId");

                    b.Navigation("DP");
                });

            modelBuilder.Entity("DepartmentLecture", b =>
                {
                    b.HasOne("DBexam.Models.Department", null)
                        .WithMany()
                        .HasForeignKey("DeparetmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBexam.Models.Lecture", null)
                        .WithMany()
                        .HasForeignKey("LecturesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LectureStudent", b =>
                {
                    b.HasOne("DBexam.Models.Lecture", null)
                        .WithMany()
                        .HasForeignKey("LecturesListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DBexam.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DBexam.Models.Department", b =>
                {
                    b.Navigation("Students");
                });
#pragma warning restore 612, 618
        }
    }
}
