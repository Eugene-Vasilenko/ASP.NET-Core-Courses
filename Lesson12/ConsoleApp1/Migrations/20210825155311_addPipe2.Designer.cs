﻿// <auto-generated />
using System;
using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ConsoleApp1.Migrations
{
    [DbContext(typeof(LessonsDbContext))]
    [Migration("20210825155311_addPipe2")]
    partial class addPipe2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ConsoleApp1.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pets");
                });

            modelBuilder.Entity("ConsoleApp1.Models.Pipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Length")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SerialNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Pipes");
                });

            modelBuilder.Entity("ConsoleApp1.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Floor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("BuildingFloor");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RenamedRoom");
                });

            modelBuilder.Entity("ConsoleApp1.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Grade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RoomId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ConsoleApp1.Models.StudentProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StudentRecordId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StudentRecordId")
                        .IsUnique();

                    b.ToTable("StudentProfiles");
                });

            modelBuilder.Entity("ConsoleApp1.Models.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("StudentTeacher", b =>
                {
                    b.Property<int>("StudentsId")
                        .HasColumnType("int");

                    b.Property<int>("TeachersId")
                        .HasColumnType("int");

                    b.HasKey("StudentsId", "TeachersId");

                    b.HasIndex("TeachersId");

                    b.ToTable("TeachersStudents");
                });

            modelBuilder.Entity("ConsoleApp1.Models.Bird", b =>
                {
                    b.HasBaseType("ConsoleApp1.Models.Pet");

                    b.Property<bool>("IsFlying")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTalking")
                        .HasColumnType("bit");

                    b.ToTable("Birds");
                });

            modelBuilder.Entity("ConsoleApp1.Models.Dog", b =>
                {
                    b.HasBaseType("ConsoleApp1.Models.Pet");

                    b.Property<string>("Breed")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Dogs");
                });

            modelBuilder.Entity("ConsoleApp1.Models.Pipe", b =>
                {
                    b.OwnsOne("ConsoleApp1.Models.Inch", "Diameter", b1 =>
                        {
                            b1.Property<int>("PipeId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("Denom")
                                .HasColumnType("int");

                            b1.Property<int>("Num")
                                .HasColumnType("int");

                            b1.Property<int>("Whole")
                                .HasColumnType("int");

                            b1.HasKey("PipeId");

                            b1.ToTable("Pipes");

                            b1.WithOwner()
                                .HasForeignKey("PipeId");
                        });

                    b.Navigation("Diameter");
                });

            modelBuilder.Entity("ConsoleApp1.Models.Student", b =>
                {
                    b.HasOne("ConsoleApp1.Models.Room", "Room")
                        .WithMany("Students")
                        .HasForeignKey("RoomId");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("ConsoleApp1.Models.StudentProfile", b =>
                {
                    b.HasOne("ConsoleApp1.Models.Student", "StudentRecord")
                        .WithOne("Profile")
                        .HasForeignKey("ConsoleApp1.Models.StudentProfile", "StudentRecordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("StudentRecord");
                });

            modelBuilder.Entity("StudentTeacher", b =>
                {
                    b.HasOne("ConsoleApp1.Models.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ConsoleApp1.Models.Teacher", null)
                        .WithMany()
                        .HasForeignKey("TeachersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConsoleApp1.Models.Bird", b =>
                {
                    b.HasOne("ConsoleApp1.Models.Pet", null)
                        .WithOne()
                        .HasForeignKey("ConsoleApp1.Models.Bird", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConsoleApp1.Models.Dog", b =>
                {
                    b.HasOne("ConsoleApp1.Models.Pet", null)
                        .WithOne()
                        .HasForeignKey("ConsoleApp1.Models.Dog", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConsoleApp1.Models.Room", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("ConsoleApp1.Models.Student", b =>
                {
                    b.Navigation("Profile");
                });
#pragma warning restore 612, 618
        }
    }
}
