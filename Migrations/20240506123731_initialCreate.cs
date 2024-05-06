﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workout_API.Migrations
{
    /// <inheritdoc />
    public partial class initialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MovementsPatterns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovementsPatterns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workouts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovementPatternId = table.Column<int>(type: "int", nullable: false),
                    OrderStep = table.Column<int>(type: "int", nullable: false),
                    WorkoutId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movements_MovementsPatterns_MovementPatternId",
                        column: x => x.MovementPatternId,
                        principalTable: "MovementsPatterns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movements_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BodyParts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovementId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BodyParts_Movements_MovementId",
                        column: x => x.MovementId,
                        principalTable: "Movements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WarmupSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reps = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    Distance = table.Column<float>(type: "real", nullable: true),
                    Time = table.Column<int>(type: "int", nullable: true),
                    OrderStep = table.Column<int>(type: "int", nullable: false),
                    MovementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarmupSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarmupSets_Movements_MovementId",
                        column: x => x.MovementId,
                        principalTable: "Movements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkingSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reps = table.Column<int>(type: "int", nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    Distance = table.Column<float>(type: "real", nullable: true),
                    Time = table.Column<int>(type: "int", nullable: true),
                    OrderStep = table.Column<int>(type: "int", nullable: false),
                    MovementId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkingSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkingSets_Movements_MovementId",
                        column: x => x.MovementId,
                        principalTable: "Movements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BodyParts_MovementId",
                table: "BodyParts",
                column: "MovementId");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_MovementPatternId",
                table: "Movements",
                column: "MovementPatternId");

            migrationBuilder.CreateIndex(
                name: "IX_Movements_WorkoutId",
                table: "Movements",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_WarmupSets_MovementId",
                table: "WarmupSets",
                column: "MovementId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkingSets_MovementId",
                table: "WorkingSets",
                column: "MovementId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_UserId",
                table: "Workouts",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BodyParts");

            migrationBuilder.DropTable(
                name: "WarmupSets");

            migrationBuilder.DropTable(
                name: "WorkingSets");

            migrationBuilder.DropTable(
                name: "Movements");

            migrationBuilder.DropTable(
                name: "MovementsPatterns");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
