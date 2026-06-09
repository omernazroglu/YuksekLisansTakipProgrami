using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GraduateAppTracker.Migrations
{
    /// <inheritdoc />
    public partial class AddAnnouncementDateAndQuota : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AnnouncementDate",
                table: "UniversityPrograms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quota",
                table: "UniversityPrograms",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "UniversityPrograms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AnnouncementDate", "ApplicationDate", "CreatedAt", "Quota" },
                values: new object[] { null, new DateTime(2026, 6, 23, 22, 20, 6, 781, DateTimeKind.Local).AddTicks(8690), new DateTime(2026, 6, 9, 22, 20, 6, 781, DateTimeKind.Local).AddTicks(8698), null });

            migrationBuilder.UpdateData(
                table: "UniversityPrograms",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AnnouncementDate", "ApplicationDate", "CreatedAt", "Quota" },
                values: new object[] { null, new DateTime(2026, 6, 14, 22, 20, 6, 781, DateTimeKind.Local).AddTicks(8700), new DateTime(2026, 6, 9, 22, 20, 6, 781, DateTimeKind.Local).AddTicks(8700), null });

            migrationBuilder.UpdateData(
                table: "UniversityPrograms",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AnnouncementDate", "ApplicationDate", "CreatedAt", "Quota" },
                values: new object[] { null, new DateTime(2026, 7, 9, 22, 20, 6, 781, DateTimeKind.Local).AddTicks(8702), new DateTime(2026, 6, 9, 22, 20, 6, 781, DateTimeKind.Local).AddTicks(8703), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnnouncementDate",
                table: "UniversityPrograms");

            migrationBuilder.DropColumn(
                name: "Quota",
                table: "UniversityPrograms");

            migrationBuilder.UpdateData(
                table: "UniversityPrograms",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ApplicationDate", "CreatedAt" },
                values: new object[] { new DateTime(2026, 6, 23, 21, 19, 7, 413, DateTimeKind.Local).AddTicks(7565), new DateTime(2026, 6, 9, 21, 19, 7, 413, DateTimeKind.Local).AddTicks(7573) });

            migrationBuilder.UpdateData(
                table: "UniversityPrograms",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ApplicationDate", "CreatedAt" },
                values: new object[] { new DateTime(2026, 6, 14, 21, 19, 7, 413, DateTimeKind.Local).AddTicks(7577), new DateTime(2026, 6, 9, 21, 19, 7, 413, DateTimeKind.Local).AddTicks(7578) });

            migrationBuilder.UpdateData(
                table: "UniversityPrograms",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ApplicationDate", "CreatedAt" },
                values: new object[] { new DateTime(2026, 7, 9, 21, 19, 7, 413, DateTimeKind.Local).AddTicks(7581), new DateTime(2026, 6, 9, 21, 19, 7, 413, DateTimeKind.Local).AddTicks(7582) });
        }
    }
}
