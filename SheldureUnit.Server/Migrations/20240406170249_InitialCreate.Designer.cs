﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SheldureUnit.Server.Data;

#nullable disable

namespace SheldureUnit.Server.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240406170249_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("SheldureUnit.Server.Data.ClassRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.ToTable("ClassRoom");
                });

            modelBuilder.Entity("SheldureUnit.Server.Data.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ClassRoomRefId")
                        .HasColumnType("int");

                    b.Property<int>("Day")
                        .HasColumnType("int");

                    b.Property<int>("FirstSubjectId")
                        .HasColumnType("int");

                    b.Property<int>("FirstSubjectRefId")
                        .HasColumnType("int");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int?>("ScheduleId")
                        .HasColumnType("int");

                    b.Property<int>("SecondSubjectId")
                        .HasColumnType("int");

                    b.Property<int>("SecondSubjectRefId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClassRoomRefId");

                    b.HasIndex("FirstSubjectId");

                    b.HasIndex("ScheduleId");

                    b.HasIndex("SecondSubjectId");

                    b.ToTable("Lesson");
                });

            modelBuilder.Entity("SheldureUnit.Server.Data.Schedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Group")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Schedules");
                });

            modelBuilder.Entity("SheldureUnit.Server.Data.Subject", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("SubjectDescription")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SubjectName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Subject");
                });

            modelBuilder.Entity("SheldureUnit.Server.Data.Lesson", b =>
                {
                    b.HasOne("SheldureUnit.Server.Data.ClassRoom", "ClassRoom")
                        .WithMany()
                        .HasForeignKey("ClassRoomRefId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SheldureUnit.Server.Data.Subject", "FirstSubject")
                        .WithMany()
                        .HasForeignKey("FirstSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SheldureUnit.Server.Data.Schedule", null)
                        .WithMany("Lessons")
                        .HasForeignKey("ScheduleId");

                    b.HasOne("SheldureUnit.Server.Data.Subject", "SecondSubject")
                        .WithMany()
                        .HasForeignKey("SecondSubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassRoom");

                    b.Navigation("FirstSubject");

                    b.Navigation("SecondSubject");
                });

            modelBuilder.Entity("SheldureUnit.Server.Data.Schedule", b =>
                {
                    b.Navigation("Lessons");
                });
#pragma warning restore 612, 618
        }
    }
}
