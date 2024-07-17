using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Training.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    MaxNumberOfStudents = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "MaxNumberOfStudents", "Name", "StartDate" },
                values: new object[,]
                {
                    { new Guid("3b9c895c-8dd9-41f8-8124-c2d43d623b81"), 30, "Microservicios", new DateTime(2024, 7, 15, 14, 0, 9, 587, DateTimeKind.Local).AddTicks(7338) },
                    { new Guid("b5067a9b-4b7a-4c79-b5d4-d978955ceaca"), 5000, "Ingles", new DateTime(2024, 7, 15, 14, 0, 9, 587, DateTimeKind.Local).AddTicks(7334) },
                    { new Guid("ef14acbe-35fb-4593-b912-c598625d3d29"), 200, "IA", new DateTime(2024, 7, 15, 14, 0, 9, 587, DateTimeKind.Local).AddTicks(7260) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
