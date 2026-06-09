using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GraduateAppTracker.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UniversityPrograms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UniversityName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DepartmentName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MinAlesScore = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    RequiresLanguage = table.Column<bool>(type: "bit", nullable: false),
                    MinLanguageScore = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    ApplicationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UniversityPrograms", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "UniversityPrograms",
                columns: new[] { "Id", "ApplicationDate", "CreatedAt", "DepartmentName", "MinAlesScore", "MinLanguageScore", "RequiresLanguage", "UniversityName" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 6, 23, 21, 19, 7, 413, DateTimeKind.Local).AddTicks(7565), new DateTime(2026, 6, 9, 21, 19, 7, 413, DateTimeKind.Local).AddTicks(7573), "Bilgisayar Mühendisliği", 70m, 65m, true, "Ankara Üniversitesi" },
                    { 2, new DateTime(2026, 6, 14, 21, 19, 7, 413, DateTimeKind.Local).AddTicks(7577), new DateTime(2026, 6, 9, 21, 19, 7, 413, DateTimeKind.Local).AddTicks(7578), "Yapay Zeka ve Veri Mühendisliği", 75m, null, false, "İstanbul Teknik Üniversitesi" },
                    { 3, new DateTime(2026, 7, 9, 21, 19, 7, 413, DateTimeKind.Local).AddTicks(7581), new DateTime(2026, 6, 9, 21, 19, 7, 413, DateTimeKind.Local).AddTicks(7582), "Elektrik-Elektronik Mühendisliği", 80m, 70m, true, "ODTÜ" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UniversityPrograms");
        }
    }
}
