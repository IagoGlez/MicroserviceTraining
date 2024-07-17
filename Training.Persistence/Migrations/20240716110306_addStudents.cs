using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Training.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class addStudents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("3b9c895c-8dd9-41f8-8124-c2d43d623b81"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("b5067a9b-4b7a-4c79-b5d4-d978955ceaca"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("ef14acbe-35fb-4593-b912-c598625d3d29"));

            migrationBuilder.CreateTable(
                name: "Coach",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    ExperienceYears = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    RollOnDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CommunityName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coach", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    HoursTaken = table.Column<double>(type: "REAL", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", nullable: false),
                    RollOnDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CommunityName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "MaxNumberOfStudents", "Name", "StartDate" },
                values: new object[,]
                {
                    { new Guid("1bb9b23c-ac96-4df4-b9b2-0f8b84cccad2"), 200, "IA", new DateTime(2024, 7, 16, 13, 3, 6, 360, DateTimeKind.Local).AddTicks(7114) },
                    { new Guid("815614b2-7a44-41f0-9843-1fd03ee78c49"), 30, "Microservicios", new DateTime(2024, 7, 16, 13, 3, 6, 360, DateTimeKind.Local).AddTicks(7190) },
                    { new Guid("d5f4cf21-f868-4f2c-898b-90f48fbd3361"), 5000, "Ingles", new DateTime(2024, 7, 16, 13, 3, 6, 360, DateTimeKind.Local).AddTicks(7186) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Coach");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("1bb9b23c-ac96-4df4-b9b2-0f8b84cccad2"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("815614b2-7a44-41f0-9843-1fd03ee78c49"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("d5f4cf21-f868-4f2c-898b-90f48fbd3361"));

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
    }
}
