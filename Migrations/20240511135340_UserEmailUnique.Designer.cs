﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Workout_API.DBContexts;

#nullable disable

namespace Workout_API.Migrations
{
    [DbContext(typeof(DBContext))]
    [Migration("20240511135340_UserEmailUnique")]
    partial class UserEmailUnique
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Workout_API.Models.BodyPart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("MovementId")
                        .HasColumnType("int");

                    b.HasKey("Id", "Name");

                    b.HasIndex("MovementId");

                    b.ToTable("BodyParts");
                });

            modelBuilder.Entity("Workout_API.Models.Movement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MovementPatternId")
                        .HasColumnType("int");

                    b.Property<string>("MovementPatternName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderStep")
                        .HasColumnType("int");

                    b.Property<int>("WorkoutId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutId");

                    b.HasIndex("MovementPatternId", "MovementPatternName");

                    b.ToTable("Movements");
                });

            modelBuilder.Entity("Workout_API.Models.MovementPattern", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id", "Name");

                    b.ToTable("MovementsPatterns");
                });

            modelBuilder.Entity("Workout_API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id", "Email");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Workout_API.Models.WarmupSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float?>("Distance")
                        .HasColumnType("real");

                    b.Property<int>("MovementId")
                        .HasColumnType("int");

                    b.Property<int>("OrderStep")
                        .HasColumnType("int");

                    b.Property<int?>("Reps")
                        .HasColumnType("int");

                    b.Property<int?>("Time")
                        .HasColumnType("int");

                    b.Property<int?>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovementId");

                    b.ToTable("WarmupSets");
                });

            modelBuilder.Entity("Workout_API.Models.WorkingSet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float?>("Distance")
                        .HasColumnType("real");

                    b.Property<int>("MovementId")
                        .HasColumnType("int");

                    b.Property<int>("OrderStep")
                        .HasColumnType("int");

                    b.Property<int?>("Reps")
                        .HasColumnType("int");

                    b.Property<int?>("Time")
                        .HasColumnType("int");

                    b.Property<int?>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovementId");

                    b.ToTable("WorkingSets");
                });

            modelBuilder.Entity("Workout_API.Models.Workout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserEmail")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId", "UserEmail");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("Workout_API.Models.BodyPart", b =>
                {
                    b.HasOne("Workout_API.Models.Movement", null)
                        .WithMany("TargetedBodyparts")
                        .HasForeignKey("MovementId");
                });

            modelBuilder.Entity("Workout_API.Models.Movement", b =>
                {
                    b.HasOne("Workout_API.Models.Workout", "Workout")
                        .WithMany("Movements")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Workout_API.Models.MovementPattern", "MovementPattern")
                        .WithMany()
                        .HasForeignKey("MovementPatternId", "MovementPatternName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MovementPattern");

                    b.Navigation("Workout");
                });

            modelBuilder.Entity("Workout_API.Models.WarmupSet", b =>
                {
                    b.HasOne("Workout_API.Models.Movement", "Movement")
                        .WithMany("WarmupSets")
                        .HasForeignKey("MovementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movement");
                });

            modelBuilder.Entity("Workout_API.Models.WorkingSet", b =>
                {
                    b.HasOne("Workout_API.Models.Movement", "Movement")
                        .WithMany("WorkingSets")
                        .HasForeignKey("MovementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movement");
                });

            modelBuilder.Entity("Workout_API.Models.Workout", b =>
                {
                    b.HasOne("Workout_API.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId", "UserEmail");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Workout_API.Models.Movement", b =>
                {
                    b.Navigation("TargetedBodyparts");

                    b.Navigation("WarmupSets");

                    b.Navigation("WorkingSets");
                });

            modelBuilder.Entity("Workout_API.Models.Workout", b =>
                {
                    b.Navigation("Movements");
                });
#pragma warning restore 612, 618
        }
    }
}
